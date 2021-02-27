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
        return GetIconTypeForLevelType();
    }

    public IconType GetIconTypeForLevelType()
    {
        switch (levelType)
        {
            case LevelType.Reach:
                return IconType.LevelType_Reach;
            case LevelType.Sport:
                return IconType.LevelType_Sport;
            case LevelType.Collect:
                return IconType.LevelType_Collect;
            default:
                return IconType.None;
        }
    }
}