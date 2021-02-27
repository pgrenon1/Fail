using Sirenix.OdinInspector.Editor;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Create a new type of Settings Asset.
class IDSettings : ScriptableObject
{
    public const string k_IDSettingsPath = "Assets/Editor/IDSettings.asset";

    //[SerializeField, Sirenix.OdinInspector.FilePath]
    //public string bootstrapScenePath;

    //[SerializeField, Sirenix.OdinInspector.FilePath]
    //public string gameMenuScenePath;

    internal static IDSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<IDSettings>(k_IDSettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<IDSettings>();
            AssetDatabase.CreateAsset(settings, k_IDSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
}

// Register a SettingsProvider
static class IDSettingsRegister
{
    private static PropertyTree _propertyTree;

    [SettingsProvider]
    public static SettingsProvider CreateCustomSettingsProvider()
    {
        // First parameter is the path in the Settings window.
        // Second parameter is the scope of this setting: it only appears in the Project Settings window.
        var provider = new SettingsProvider("Project/IDSettings", SettingsScope.Project)
        {
            // By default the last token of the path is used as display name if no label is provided.
            label = "ID",

            guiHandler = (searchContext) =>
            {
                var settings = IDSettings.GetSerializedSettings();

                if (_propertyTree == null)
                {
                    _propertyTree = PropertyTree.Create(settings);
                }

                _propertyTree.Draw();
            },

            // Populate the search keywords to enable smart search filtering and label highlighting:
            keywords = new HashSet<string>(new[] { "ID", "Interior Designs" })
        };

        return provider;
    }
}