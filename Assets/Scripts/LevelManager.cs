using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : OdinSerializedSingletonBehaviour<LevelManager>
{
    public LevelEndScreen levelEndScreen;
    public float levelEndShotDuration = 2f;

    public Level CurrentLevel { get; set; }

    public float Timer { get; private set; }

    private bool _timerIsStarted = false;

    protected override void Awake()
    {
        base.Awake();

        //SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public void SetRecordTimeForCurrentLevel()
    {
        if (CurrentLevel != null)
        {
            float record = 0f;
            if (PersistenceManager.Instance.GetLevelRecord(CurrentLevel.LevelData, ref record))
            {
                if (Timer < record)
                {
                    PersistenceManager.Instance.SetLevelRecord(CurrentLevel.LevelData, Timer);

                    CurrentLevel.Record = Timer;
                }

                CurrentLevel.Record = record;
            }
            else
            {
                PersistenceManager.Instance.SetLevelRecord(CurrentLevel.LevelData, Timer);

                CurrentLevel.Record = Timer;
            }
        }
    }

    public LevelData GetLevelDataForScene(Scene scene)
    {
        foreach (var chapterData in GameManager.Instance.chapters)
        {
            foreach (var chapterStep in chapterData.chapterSteps)
            {
                foreach (var level in chapterStep.levels)
                {
                    if (level.path == scene.path)
                        return level;
                }
            }
        }

        return null;
    }

    //private void OnApplicationQuit()
    //{
    //    SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    //}

    //private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    //Debug.Log(scene.name);

    //    InitLevel();

    //    if (CurrentLevel)
    //        StartLevel();
    //}

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (_timerIsStarted)
            Timer += Time.deltaTime;
    }

    private void ResetTimer()
    {
        Timer = 0f;
    }

    private void StopTimer()
    {
        _timerIsStarted = false;
    }

    private void StartTimer()
    {
        _timerIsStarted = true;
    }

    public void SkipLevel()
    {
        CurrentLevel.EndLevel(null);
    }

    public void StartLevel()
    {
        StartCoroutine(DoStartLevel());
    }

    private IEnumerator DoStartLevel()
    {
        PlayerManager.Instance.SpawnPlayer();

        yield return StartCoroutine(GameManager.Instance.DoHideLoadingScreen());

        CurrentLevel.StartLevel();

        InputManager.Instance.GameInputs.PlayerActions.Enable();

        StartTimer();
    }

    public void RestartLevel()
    {
        ResetTimer();

        PlayerManager.Instance.ResetPlayer();
    }

    public void EndLevel(LevelEndConditionRuntime levelEndCondition)
    {
        StopTimer();

        SetRecordTimeForCurrentLevel();

        // Disable Player's Inputs
        InputManager.Instance.GameInputs.PlayerActions.Disable();

        PlayerManager.Instance.Player.visualsParent.SetActive(false);
        PlayerManager.Instance.Player.PlayDeathFeedback(PlayerManager.Instance.Player.transform.position, Quaternion.LookRotation(PlayerManager.Instance.Player.Rigidbody.velocity));
        PlayerManager.Instance.Player.Rigidbody.isKinematic = true;


        StartCoroutine(DoLevelEndSequence(levelEndCondition));
    }

    private IEnumerator DoLevelEndSequence(LevelEndConditionRuntime levelEndCondition)
    {
        if (levelEndCondition != null)
        {
            // ?
        }

        ShowLevelCompletedScreen();

        yield return new WaitForSeconds(levelEndShotDuration);

        GameManager.Instance.UnloadLevel();
    }

    private void ShowLevelCompletedScreen()
    {
        levelEndScreen.Show(null);
    }

    public void InitLevel()
    {
        //Debug.Log("Initializing level");

        CurrentLevel = FindObjectOfType<Level>();

        if (CurrentLevel == null)
        {
            //Debug.Log("No Level");
            return;
        }

        CurrentLevel.Init();
    }
}
