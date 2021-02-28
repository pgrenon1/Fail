using UnityEditor;
using UnityEditor.SceneManagement;

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
				EditorSceneManager.OpenScene(Index.Instance.sceneIndex.bootstrapScenePath, OpenSceneMode.Additive);
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
		for (var i = 0; i < EditorSceneManager.sceneCount; i++)
		{
			if (EditorSceneManager.GetSceneAt(i) == EditorSceneManager.GetActiveScene())
			{
				return i;
			}
		}

		return -1;
	}

	private static bool SetActiveSceneIndex(int index)
	{
		if (index < EditorSceneManager.sceneCount)
		{
			EditorSceneManager.SetActiveScene(EditorSceneManager.GetSceneAt(index));
			return true;
		}

		return false;
	}
}
