using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChapterUI : MonoBehaviour
{
    [Space]
    public TextMeshProUGUI titleText;
    public Image chapterImage;
    public TextMeshProUGUI progressText;
    public IDButton selectButton;

    public ChapterData ChapterData { get; private set; }
    
    private ChapterSelect _chapterSelect;

    public void Setup(ChapterData chapterData, ChapterSelect chapterSelect)
    {
        ChapterData = chapterData;
        _chapterSelect = chapterSelect;

        gameObject.name = "ChapterUI_" + ChapterData.name;

        titleText.SetText(ChapterData.title);
        progressText.SetText(GetProgressString());
        chapterImage.sprite = ChapterData.image;

        selectButton.OnButtonSelected += SelectButton_OnButtonSelected;
        selectButton.onClick.AddListener(_chapterSelect.Submit);
    }

    private void SelectButton_OnButtonSelected()
    {
        _chapterSelect.SetSelection(this);
    }

    private string GetProgressString()
    {
        return PersistenceManager.Instance.GetChapterProgress(ChapterData).ToString();
    }
}