using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSelect : GameMenuPanel
{
    public IDButton arrowLeft;
    public IDButton arrowRight;
    public IDButton backButton;
    public ChapterUI chapterUIPrefab;
    public Transform chapterUIsParent;

    private List<ChapterUI> _chapterUIs = new List<ChapterUI>();
    private ScrollRect _scrollRect;
    private int _selectionIndex;

    private void Awake()
    {
        _scrollRect = chapterUIsParent.GetComponentInParent<ScrollRect>();

        Setup(GameManager.Instance.chapters);
    }

    private void Start()
    {
        //InputManager.Instance.GameInputs.MenuActions.NavLeft.performed += ctx => SelectLeft();
        //InputManager.Instance.GameInputs.MenuActions.NavRight.performed += ctx => SelectRight();
    }

    public void Setup(List<ChapterData> chapterDatas)
    {
        foreach (var chapterData in chapterDatas)
        {
            var chapterUI = Instantiate(chapterUIPrefab, chapterUIsParent);
            chapterUI.Setup(chapterData, this);
            _chapterUIs.Add(chapterUI);
        }
    }

    public void Submit()
    {
        GameMenu.GoToLevelSelect(_chapterUIs[_selectionIndex].ChapterData);
    }

    public void SetSelection(ChapterUI chapterUI)
    {
        var indexToSelect = _chapterUIs.IndexOf(chapterUI);

        SetSelection(indexToSelect);
    }

    public void SetSelection(int newIndex)
    {
        _selectionIndex = Mathf.Clamp(newIndex, 0, _chapterUIs.Count - 1);

        ScrollToSelected(_chapterUIs[_selectionIndex]);
    }

    public void ScrollToSelected(ChapterUI chapterUI)
    {
        Canvas.ForceUpdateCanvases();

        _scrollRect.content.anchoredPosition =
            (Vector2)_scrollRect.transform.InverseTransformPoint(_scrollRect.content.position)
            - (Vector2)_scrollRect.transform.InverseTransformPoint(chapterUI.transform.position);
    }

    public void SelectLeft()
    {
        SetSelection(_selectionIndex - 1);
    }

    public void SelectRight()
    {
        SetSelection(_selectionIndex + 1);
    }

    public void GoToMainMenu()
    {
        GameMenu.GoToMainMenu();
    }
}
