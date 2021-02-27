using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : OdinSerializedGUIDScriptableObject, IIconProvider
{
    [FilePath, Required]
    public string path;
    public bool isUnlockedByDefault;
    public string title;
    public LevelType levelType;
    public Sprite levelImage;

    public IconType GetIconType()
    {
        return IconType.None;
    }
}