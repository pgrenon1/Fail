using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelEndScreen : MonoBehaviour, IUIElement
{
    public Image backgroundImage;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordTimeText;

    public void Show(Action shownCallback)
    {
        gameObject.SetActive(true);

        backgroundImage.DOFade(1f, 0.3f);

        var timeSpan = TimeSpan.FromSeconds(LevelManager.Instance.Timer);
        timeText.SetText(timeSpan.ToString("m\\:ss\\.fff"));

        timeSpan = TimeSpan.FromSeconds(LevelManager.Instance.CurrentLevel.Record);
        recordTimeText.SetText(timeSpan.ToString("m\\:ss\\.fff"));
    }

    public void Hide(Action hiddenCallback)
    {
        backgroundImage.DOFade(0f, 0.7f).OnComplete(() => gameObject.SetActive(true));
    }
}
