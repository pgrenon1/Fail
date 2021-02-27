using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : OdinSerializedSingletonBehaviour<GameManager>
{
        public bool levelsAreScenes = true;
    [HideIf("levelsAreScenes"), Sirenix.OdinInspector.FilePath]
    public string levelScenePath;

    public List<ChapterData> chapters = new List<ChapterData>();

    private LoadingScreen _loadingScreen;

    private bool _gameIsPaused;
    public bool GameIsPaused
    {
        get
        {
            return _gameIsPaused;
        }
        private set
        {
            _gameIsPaused = value;

            if (_gameIsPaused)
            {
                _lastTimescaleIndex = _timescaleIndex;

                ChangeTimeScale(0);
            }
            else
            {
                ChangeTimeScale(_lastTimescaleIndex);
            }
        }
    }

    private int _lastTimescaleIndex;
    private List<float> _timescales = new List<float>() { 0f, 0.2f, 0.5f, 1f, 1.5f, 2f };

    private int _timescaleIndex;

    protected override void Awake()
    {
        base.Awake();

        _timescaleIndex = _timescales.IndexOf(1f);
        _lastTimescaleIndex = _timescaleIndex;

        _loadingScreen = FindObjectOfType<LoadingScreen>();

        StartGame();
    }

    private void StartGame()
    {
        if (SceneManager.sceneCount == 1)
        {
            LoadGameMenuSync();
        }

        HideLoadingScreen();
    }

    public void LoadGameMenuSync()
    {
        var gameMenubuildIndex = Index.Instance.SceneIndex.GameMenuSceneBuildIndex;
        SceneManager.LoadScene(gameMenubuildIndex, LoadSceneMode.Additive);
    }

    public void SetActiveScene(Scene scene)
    {
        SceneManager.SetActiveScene(scene);
    }

    public void TogglePause()
    {
        GameIsPaused = !GameIsPaused;
    }

    public void ChangeTimeScale(int indexDelta)
    {
        _timescaleIndex = Mathf.Clamp(_timescaleIndex - indexDelta, 0, _timescales.Count - 1);
        Time.timeScale = _timescales[_timescaleIndex];
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#else
        Application.Quit();
#endif
    }

    public void ShowLoadingScreen(Action loadingScreenShownCallback = null)
    {
        _loadingScreen.Show(loadingScreenShownCallback);
    }

    public void HideLoadingScreen(Action loadingScreenHiddenCallback = null)
    {
        _loadingScreen.Hide(loadingScreenHiddenCallback);
    }

    public IEnumerator DoHideLoadingScreen()
    {
        var loadingScreenHidden = false;
        HideLoadingScreen(() => { loadingScreenHidden = true; });

        yield return new WaitWhile(() => !loadingScreenHidden);
    }

    public IEnumerator DoShowLoadingScreen()
    {
        var loadingScreenShown = false;
        ShowLoadingScreen(() => { loadingScreenShown = true; });

        yield return new WaitWhile(() => !loadingScreenShown);
    }

    public void LoadLevel(LevelData levelData, SceneNullable sceneToUnload = null)
    {
        var buildIndex = SceneUtility.GetBuildIndexByScenePath(levelData.path);

        StartCoroutine(DoLoadLevel(buildIndex, sceneToUnload));
    }

    /// <summary>
    /// 1. show loading screen
    /// 2. [async] unload current scene if needed
    /// 3. [async] load Level scene
    /// 4. init Level
    /// 5. hide loading screen
    /// 6. start Level
    /// </summary>
    public IEnumerator DoLoadLevel(int levelSceneBuildIndex, SceneNullable sceneToUnload = null)
    {
        // show loading screen
        yield return StartCoroutine(DoShowLoadingScreen());

        // if we have a scene to unload, unload it
        AsyncOperation unloadSceneAsync = null;
        if (sceneToUnload != null)
        {
            var scene = sceneToUnload.scene;

            unloadSceneAsync = UnloadSceneAsync(scene);
        }

        var loadingSceneAsync = LoadSceneAsync(levelSceneBuildIndex);

        while (!unloadSceneAsync.isDone || !loadingSceneAsync.isDone)
        {
            //Debug.Log("Unload: " + unloadSceneAsync.progress + "\n"
            //        + "Load: " + loadingSceneAsync.progress);
            yield return null;
        }

        // setting active scene
        var loadedLevelSceneIndex = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(loadedLevelSceneIndex);

        //yield return StartCoroutine(DoHideLoadingScreen());
    }

    public void UnloadLevel()
    {
        StartCoroutine(DoUnloadLevel());
    }

    /// <summary>
    /// 1. show loading screen
    /// 2. [async] unload current Level scene if needed
    /// 3. [async] load GameMenu scene
    /// 4. init GameMenu
    /// 5. hide loading screen
    /// 6. start GameMenu
    /// </summary>
    private IEnumerator DoUnloadLevel()
    {
        // show loading screen
        yield return StartCoroutine(DoShowLoadingScreen());

        PlayerManager.Instance.DestroyPlayer();

        // if we have a level to unload, unload it
        var levelSceneNullable = GetLoadedLevelScene();

        AsyncOperation unloadLevelSceneAsync = null;
        if (levelSceneNullable != null)
        {
            unloadLevelSceneAsync = UnloadSceneAsync(levelSceneNullable.scene);
        }

        // load game menu in additive mode
        var loadGameMenuSceneAsync = LoadSceneAsync(Index.Instance.SceneIndex.GameMenuSceneBuildIndex, LoadSceneMode.Additive);

        while (!unloadLevelSceneAsync.isDone || !loadGameMenuSceneAsync.isDone)
        {
            //Debug.Log("Unload: " + unloadLevelSceneAsync.progress + "\n"
            //        + "Load: " + loadGameMenuSceneAsync.progress);
            yield return null;
        }

        // setting active scene
        var loadedLevelSceneIndex = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(loadedLevelSceneIndex);

        yield return StartCoroutine(DoHideLoadingScreen());
    }

    private SceneNullable GetLoadedLevelScene()
    {
        var level = FindObjectOfType<Level>();

        if (level)
        {
            return new SceneNullable(level.gameObject.scene);
        }

        return null;
    }

    private AsyncOperation UnloadSceneAsync(Scene scene)
    {
        return SceneManager.UnloadSceneAsync(scene);
    }

    private AsyncOperation LoadSceneAsync(int sceneBuildIndex, LoadSceneMode loadSceneMode = LoadSceneMode.Additive)
    {
        return SceneManager.LoadSceneAsync(sceneBuildIndex, loadSceneMode);
    }
}

public class SceneNullable
{
    public Scene scene;

    public SceneNullable(Scene scene)
    {
        this.scene = scene;
    }
}