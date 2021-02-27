using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : GameMenuPanel
{
    public GameObject chapterStepUIPrefab;
    public LevelUI levelUIPrefab;
    public Transform chapterStepsParent;
    public Button backButton;

    public Selectable PreviousSelectable { get; set; }

    private ChapterData _chapterData;
    private List<KeyValuePair<ChapterStepData, List<LevelUI>>> _chapterSteoDatas = new List<KeyValuePair<ChapterStepData, List<LevelUI>>>();

    private void Start()
    {
        backButton.onClick.AddListener(GameMenu.GoBack);
    }

    public void SetupRepeatable(ChapterData chapterData)
    {
        _chapterData = chapterData;

        if (_chapterSteoDatas != null && _chapterSteoDatas.Count > 0)
        {
            foreach (var entry in _chapterSteoDatas)
            {
                List<LevelUI> levelUIs = entry.Value;

                foreach (var levelUI in levelUIs)
                {
                    Destroy(levelUI.gameObject);
                }
            }
        }

        foreach (Transform chapterStep in chapterStepsParent)
        {
            Destroy(chapterStep.gameObject);
        }

        _chapterSteoDatas = new List<KeyValuePair<ChapterStepData, List<LevelUI>>>();

        for (int i = 0; i < _chapterData.chapterSteps.Count; i++)
        {
            var chapterStep = _chapterData.chapterSteps[i];

            var chapterStepUI = Instantiate(chapterStepUIPrefab, chapterStepsParent);

            var chapterStepLevelUIs = new List<LevelUI>();

            for (int j = 0; j < chapterStep.levels.Count; j++)
            {
                var level = chapterStep.levels[j];

                var levelUI = Instantiate(levelUIPrefab, chapterStepUI.transform);

                levelUI.Setup(level);
                levelUI.LevelSelect = this;
                levelUI.gameObject.name = "levelUI " + GameManager.Instance.chapters.IndexOf(chapterData) + "_" + i + "_" + j;

                chapterStepLevelUIs.Add(levelUI);
            }

            _chapterSteoDatas.Add(new KeyValuePair<ChapterStepData, List<LevelUI>>(chapterStep, chapterStepLevelUIs));
        }
    }

    public override void SetupNavigation()
    {
        base.SetupNavigation();

        var navTemp = Navigation.defaultNavigation;

        for (int i = 0; i < _chapterSteoDatas.Count; i++)
        {
            ChapterStepData chapterStepData = _chapterSteoDatas[i].Key;
            List<LevelUI> levelUIs = _chapterSteoDatas[i].Value;

            for (int j = 0; j < levelUIs.Count; j++)
            {
                var levelUI = levelUIs[j];
                var button = levelUI.button;

                button.SetDefaultExplicitNavigation();

                navTemp = button.navigation;
                if (navTemp.selectOnRight == backButton && i < _chapterSteoDatas.Count)
                {
                    navTemp.selectOnRight = null;
                }

                button.navigation = navTemp;
            }
        }

        SetBackButtonNavigation();
    }

    private Navigation SetBackButtonNavigation()
    {
        Navigation navTemp;
        backButton.SetDefaultExplicitNavigation();
        navTemp = backButton.navigation;
        //navTemp.selectOnUp = _chapterSteoDatas[_chapterSteoDatas.Count - 1].Value[0].button;
        backButton.navigation = navTemp;
        return navTemp;
    }
}