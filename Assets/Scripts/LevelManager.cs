using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : OdinSerializedSingletonBehaviour<LevelManager>
{
    public float levelEndShotDuration = 2f;

    public Level CurrentLevel { get; set; }

    protected override void Awake()
    {
        base.Awake();

        //SceneManager.sceneLoaded += SceneManager_sceneLoaded;
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
    }

    public void EndLevel(LevelEndConditionRuntime levelEndCondition)
    {
        // Disable Player's Inputs
        InputManager.Instance.GameInputs.PlayerActions.Disable();

        PlayerManager.Instance.Player.visualsParent.SetActive(false);
        PlayerManager.Instance.Player.PlayDeathFeedback(Quaternion.LookRotation(PlayerManager.Instance.Player.Rigidbody.velocity));
        PlayerManager.Instance.Player.Rigidbody.isKinematic = true;

        StartCoroutine(DoLevelEndSequence(levelEndCondition));
    }

    private IEnumerator DoLevelEndSequence(LevelEndConditionRuntime levelEndCondition)
    {
        if (levelEndCondition != null)
        {
            // ?
        }

        yield return new WaitForSeconds(levelEndShotDuration);

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
