using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneIndex : OdinSerializedScriptableObject
{
    [SerializeField, Sirenix.OdinInspector.FilePath]
    public string bootstrapScenePath;

    [SerializeField, Sirenix.OdinInspector.FilePath]
    public string gameMenuScenePath;

    public int GameMenuSceneBuildIndex
    {
        get
        {
            return SceneUtility.GetBuildIndexByScenePath(gameMenuScenePath);
        }
    }

    public int BootStrapSceneBuildIndex
    {
        get
        {
            return SceneUtility.GetBuildIndexByScenePath(bootstrapScenePath);
        }
    }
}
