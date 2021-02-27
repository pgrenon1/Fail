using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class EditorSceneOrderer
{
	const string activeSceneIndexKey = "ActiveSceneIndex";

	static EditorSceneOrderer()
	{
		EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
	}

	private static void OnPlayModeStateChanged(PlayModeStateChange targetState)
	{
		if (targetState == PlayModeStateChange.ExitingEditMode)
		{
			EditorPrefs.SetInt(activeSceneIndexKey, GetActiveSceneIndex());

			int bootStrapSceneBuildIndex = Index.Instance.SceneIndex.BootStrapSceneBuildIndex;
			var bootstrapIsLoaded = Utils.SceneIsLoaded(bootStrapSceneBuildIndex);

			if (!bootstrapIsLoaded)
			{
#if UNITY_EDITOR
				EditorSceneManager.OpenScene(Index.Instance.sceneIndex.bootstrapScenePath, OpenSceneMode.Additive);
#else
				SceneManager.LoadScene(Index.Instance.sceneIndex.BootStrapSceneBuildIndex, LoadSceneMode.Additive);
#endif
			}

			SetActiveSceneIndex(Utils.GetIndexOfLoadedScene(bootStrapSceneBuildIndex));
		}

		if (targetState == PlayModeStateChange.EnteredEditMode)
		{
			if (EditorPrefs.HasKey(activeSceneIndexKey))
			{
				SetActiveSceneIndex(EditorPrefs.GetInt(activeSceneIndexKey, 0));
			}
		}
	}

	private static int GetActiveSceneIndex()
	{
		for (var i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i) == SceneManager.GetActiveScene())
			{
				return i;
			}
		}

		return -1;
	}

	private static bool SetActiveSceneIndex(int index)
	{
		if (index < SceneManager.sceneCount)
		{
			SceneManager.SetActiveScene(SceneManager.GetSceneAt(index));
			return true;
		}

		return false;
	}
}