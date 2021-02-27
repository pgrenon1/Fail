using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameMenuPanel : MonoBehaviour, IUIElement
{
    public GameMenu GameMenu { get; set; }

    public void GoBack()
    {
        GameMenu.GoBack();
    }

    public void WaitAndSetupNavigation()
    {
        StartCoroutine(DoWaitAndSetupNavigation());
    }

    private IEnumerator DoWaitAndSetupNavigation()
    {
        yield return 1;

        SetupNavigation();

        SelectEntryPoint();
    }

    public virtual void SetupNavigation()
    {

    }

    public virtual void SelectEntryPoint()
    {
        var selectable = GetComponentInChildren<Selectable>();

        Select(selectable);
    }

    public void Select(Selectable selectable)
    {
        selectable.Select();
        selectable.OnSelect(null);
    }

    #region IUIElement interface
    public virtual void Show(Action shownCallback)
    {
        gameObject.SetActive(true);

        if (shownCallback != null)
            shownCallback.Invoke();
    }

    public virtual void Hide(Action hiddenCallback)
    {
        gameObject.SetActive(false);

        if (hiddenCallback != null)
            hiddenCallback.Invoke();
    }
    #endregion
}
