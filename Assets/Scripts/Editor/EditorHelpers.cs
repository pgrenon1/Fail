using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EditorHelpers
{
    [MenuItem("InteriorDesigns/Add Bootstrap Scene")]
    public static void AddBootstrapScene()
    {
        Utils.LoadSceneEditor(Index.Instance.SceneIndex.bootstrapScenePath, OpenSceneMode.Additive);
    }

    private static List<Scene> GetScenesToUnload(int sceneToKeepBuildIndex)
    {
        var scenes = new List<Scene>();

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);

            var bootstrapBuildIndex = Index.Instance.SceneIndex.BootStrapSceneBuildIndex;

            if (scene.buildIndex != bootstrapBuildIndex && scene.buildIndex != sceneToKeepBuildIndex)
                scenes.Add(scene);
        }

        return scenes;
    }

    public static void AddLevel(Level level)
    {
        var alreadyLoadedLevel = UnityEngine.Object.FindObjectOfType<Level>();
        if (alreadyLoadedLevel)
            UnityEngine.Object.DestroyImmediate(alreadyLoadedLevel.gameObject);

        PrefabUtility.InstantiatePrefab(level);
    }

    [MenuItem("InteriorDesigns/Load Game Menu Scene")]
    public static void LoadGameMenuScene()
    {
        EditorSceneManager.SaveOpenScenes();

        LoadSceneWithBootstrap(Index.Instance.SceneIndex.GameMenuSceneBuildIndex);
    }

    public static void LoadSceneWithBootstrap(int buildIndexOfSceneToLoad)
    {
        Utils.LoadSceneEditor(Index.Instance.SceneIndex.bootstrapScenePath, OpenSceneMode.Single);

        Utils.LoadSceneEditor(Index.Instance.SceneIndex.gameMenuScenePath, OpenSceneMode.Additive);
    }

    //private static bool SceneIsLoaded(int sceneBuildIndex)
    //{

    //}

    private static void UnloadScenes(List<Scene> scenesToUnload)
    {
        for (int i = 0; i < scenesToUnload.Count; i++)
        {
            SceneManager.UnloadSceneAsync(scenesToUnload[i]);
        }
    }
}
