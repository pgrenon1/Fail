using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour, ISelectHandler
{
    public Image backgroundImage;
    public Image levelImage;
    public Image levelTypeIcon;
    public Button button;

    public LevelData LevelData { get; private set; }
    public LevelSelect LevelSelect { get; set; } 

    public void Setup(LevelData levelData)
    {
        LevelData = levelData;

        levelImage.sprite = LevelData.levelImage;

        var isUnlocked = PersistenceManager.Instance.LevelIsUnlocked(LevelData);

        button.interactable = isUnlocked;

        Sprite iconSprite;
        if (isUnlocked)
        {
            iconSprite = Index.Instance.IconDictionary.GetIcon(LevelData.GetIconType());
        }
        else
        {
            iconSprite = Index.Instance.IconDictionary.GetIcon(IconType.Lock);
        }

        levelTypeIcon.sprite = iconSprite;
    }

    public void LoadLevel()
    {
        GameManager.Instance.LoadLevel(LevelData, new SceneNullable(gameObject.scene));
    }

    public void OnSelect(BaseEventData eventData)
    {
        LevelSelect.PreviousSelectable = button;
    }
}
