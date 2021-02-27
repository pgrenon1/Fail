using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MaterialGenerator : OdinEditorWindow
{
    [MenuItem("Tools/ID/MaterialGenerator")]
    private static void OpenWindow()
    {
        GetWindow<MaterialGenerator>().Show();
    }

    public Material baseMaterial;
    [FolderPath]
    public string outputPath;

    [Button("Generate Materials From Selected Textures")]
    public void GenerateMaterials()
    {
        if (string.IsNullOrEmpty(outputPath))
            return;

        var selected = Selection.objects;

        foreach (var selectedObject in selected)
        {
            var selectedTexture = selectedObject as Texture;
            if (selectedTexture != null)
            {
                var newMaterial = new Material(baseMaterial);
                newMaterial.mainTexture = selectedTexture;
                AssetDatabase.CreateAsset(newMaterial, outputPath + "Particle_" + selectedTexture.name + ".mat");
            }
        }

        AssetDatabase.SaveAssets();
    }
}
