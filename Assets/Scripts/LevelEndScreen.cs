using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelEndScreen : MonoBehaviour, IUIElement
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordTimeText;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show(Action shownCallback)
    {
        _canvasGroup.DOFade(1f, 0.3f);

        var timeSpan = TimeSpan.FromSeconds(LevelManager.Instance.Timer);
        timeText.SetText(timeSpan.ToString("m\\:ss\\.fff"));

        timeSpan = TimeSpan.FromSeconds(LevelManager.Instance.CurrentLevel.Record);
        recordTimeText.SetText(timeSpan.ToString("m\\:ss\\.fff"));
    }

    public void Hide(Action hiddenCallback)
    {
        _canvasGroup.DOFade(0f, 0.7f);
    }
}
