using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerSource))]
public class LevelEndTriggerZone : MonoBehaviour
{
    public bool fulfillOnExit = false;
    public bool fulfillOnPlayer = true;

    [HideIf("fulfillOnPlayer")]
    public List<Collider> targetColliders = new List<Collider>();

    private TriggerSource _triggerSource;

    public LevelEndCondition_Trigger LevelEndCondition_Trigger { get; set; }

    private void Start()
    {
        _triggerSource = GetComponent<TriggerSource>();

        if (fulfillOnExit)
            _triggerSource.OnSourceTriggerExit += TriggerSource_OnSourceTriggerExit;
        else
            _triggerSource.OnSourceTriggerEnter += TriggerSource_OnSourceTriggerEnter;
    }

    private void TriggerSource_OnSourceTriggerExit(Collider other)
    {
        Trigger(other);
    }

    private void TriggerSource_OnSourceTriggerEnter(Collider other)
    {
        Trigger(other);
    }

    private void Trigger(Collider other)
    {
        if (fulfillOnPlayer)
        {
            if (!Utils.IsPlayerGameObject(other.gameObject))
                return;
        }
        else
        {
            if (!targetColliders.Contains(other))
                return;
        }

        LevelEndCondition_Trigger.Fulfill();
    }

    private void OnDisable()
    {
        if (fulfillOnExit)
            _triggerSource.OnSourceTriggerExit -= TriggerSource_OnSourceTriggerExit;
        else
            _triggerSource.OnSourceTriggerEnter -= TriggerSource_OnSourceTriggerEnter;
    }
}