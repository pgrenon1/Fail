using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : OdinSerializedSingletonBehaviour<LevelManager>
{
    public float levelEndShotDuration = 2f;

    public Level CurrentLevel { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void OnApplicationQuit()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log(scene.name);

        InitLevel();

        if (CurrentLevel)
            StartLevel();
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
        //var spawnPoint = GetSpawnPoint();
        //if (spawnPoint != null)
        //{
        //    PlayerManager.Instance.CreatePlayerController(spawnPoint.transform.position, spawnPoint.transform.rotation);
        //}
        //else
        //{
        //    Debug.Log("No SpawnPoint found!");
        //}

        yield return StartCoroutine(GameManager.Instance.DoHideLoadingScreen());

        CurrentLevel.StartLevel();

        //InputManager.Instance.GameInputs.RopeActions.Enable();
    }

    private SpawnPoint GetSpawnPoint()
    {
        var spawnPoints = FindObjectsOfType<SpawnPoint>();
        SpawnPoint editorSpawnPoint = null;
        SpawnPoint nonEditorSpawnPoint = null;

        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint.isEditorSpawnPoint)
                editorSpawnPoint = spawnPoint;
            else
                nonEditorSpawnPoint = spawnPoint;
        }

#if UNITY_EDITOR
        if (editorSpawnPoint)
            return editorSpawnPoint;
        else
            return nonEditorSpawnPoint;
#else
        if (nonEditorSpawnPoint)
            return nonEditorSpawnPoint;
        else 
            return editorSpawnPoint;
#endif
    }

    public void EndLevel(LevelEndConditionRuntime levelEndCondition)
    {
        // Disable Player's Inputs
        //InputManager.Instance.GameInputs.RopeActions.Disable();

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
