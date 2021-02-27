using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IDButton : Button
{
    public List<TransitionTarget> transitionTargets;

    public delegate void OnButtonSelect();
    public event OnButtonSelect OnButtonSelected;

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);

        if (transitionTargets != null)
        {
            foreach (var target in transitionTargets)
            {
                if (target != null)
                    target.DoStateTransition((IDSelectionState)state, instant);
            }   
        }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);

        if (OnButtonSelected != null)
            OnButtonSelected.Invoke();
    }
}