using Cinemachine;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : OdinSerializedSingletonBehaviour<LevelManager>
{
    public float levelRestartShotDuration = 0.5f;
    public float levelRestartTrackDuration = 2f;

    public LevelEndScreen levelEndScreen;
    public float levelEndShotDuration = 2f;
    public float levelEndScreenDuration = 2f;

    public Level CurrentLevel { get; set; }

    public float Timer { get; private set; }

    private bool _timerIsStarted = false;

    public delegate void OnLevelStartOrRestart();
    public event OnLevelStartOrRestart OnLevelStartedOrRestarted;

    protected override void Awake()
    {
        base.Awake();

        //SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public void TrySetRecordTimeForCurrentLevel()
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

        if (OnLevelStartedOrRestarted != null)
            OnLevelStartedOrRestarted();

        CurrentLevel.StartLevel();

        InputManager.Instance.GameInputs.PlayerActions.Enable();

        ResetTimer();
        StartTimer();
    }

    public void RestartLevel()
    {
        StopTimer();
        //ResetTimer();

        StartCoroutine(DoRestartLevelSequence());
        //PlayerManager.Instance.ResetPlayer();
    }

    private IEnumerator DoRestartLevelSequence()
    {
        yield return new WaitForSeconds(levelRestartShotDuration);

        var trackedDolly = CurrentLevel.dollyVCam.GetCinemachineComponent<CinemachineTrackedDolly>();
        CurrentLevel.dollyVCam.Priority = 11;
        var t = levelRestartTrackDuration;
        while (t >= 0f)
        {
            var ratio = t.Remap(levelRestartTrackDuration, 0f, trackedDolly.m_Path.MaxPos, trackedDolly.m_Path.MinPos);

            trackedDolly.m_PathPosition = ratio;

            t -= Time.deltaTime;
            yield return null;
        }

        CurrentLevel.playerTracker.ClearTrack();
        CurrentLevel.dollyVCam.Priority = 9;

        PlayerManager.Instance.ResetPlayer();

        if (OnLevelStartedOrRestarted != null)
            OnLevelStartedOrRestarted();

        StartTimer();
    }

    public void EndLevel(LevelEndConditionRuntime levelEndCondition)
    {
        StopTimer();

        TrySetRecordTimeForCurrentLevel();

        // Disable Player's Inputs
        InputManager.Instance.GameInputs.PlayerActions.Disable();

        PlayerManager.Instance.Player.visualsParent.SetActive(false);
        PlayerManager.Instance.Player.PlayDeathFeedback();
        PlayerManager.Instance.Player.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        StartCoroutine(DoLevelEndSequence(levelEndCondition));
    }

    private IEnumerator DoLevelEndSequence(LevelEndConditionRuntime levelEndCondition)
    {
        if (levelEndCondition != null)
        {
            // ?
        }

        yield return new WaitForSeconds(levelEndShotDuration);

        levelEndScreen.Show(null);

        yield return new WaitForSeconds(levelEndScreenDuration);

        GameManager.Instance.UnloadLevel();
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
