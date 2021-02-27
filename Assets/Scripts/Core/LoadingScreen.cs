using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class LoadingScreen : MonoBehaviour, IUIElement
{
    public float showDuration = 1f;
    public float hideDuration = 1f;
    public Graphic graphic;
    public TextMeshProUGUI loadingText;

    private void Awake()
    {
        graphic.gameObject.SetActive(true);
    }

    private void OnLoadingScreenHidden(Action hiddenCallback)
    {
        if (hiddenCallback != null)
            hiddenCallback.Invoke();
    }

    private void OnLoadingScreenShown(Action shownCallback)
    {
        loadingText.enabled = true;

        if (shownCallback != null)
            shownCallback.Invoke();
    }   
    
    public void Hide(Action hiddenCallback)
    {
        loadingText.enabled = false;

        graphic.DOFade(0f, hideDuration).OnComplete(() => OnLoadingScreenHidden(hiddenCallback));

        graphic.raycastTarget = false;
    }

    public void Show(Action shownCallback)
    {
        graphic.DOFade(1f, showDuration).OnComplete(() => OnLoadingScreenShown(shownCallback));

        graphic.raycastTarget = false;
    }
}
