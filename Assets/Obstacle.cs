using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool destroyOnTrigger = true;
    
    [ShowIf("destroyOnTrigger")]
    public ParticleSystem destructionVFX;
    [ShowIf("destroyOnTrigger")]
    public AudioClip destructionClip;

    private TriggerSource _triggerSource;

    private void Start()
    {
        _triggerSource = GetComponentInChildren<TriggerSource>();

        _triggerSource.OnSourceTriggerEnter += TriggerSource_OnSourceTriggerEnter;
    }

    private void TriggerSource_OnSourceTriggerEnter(Collider other)
    {
        if (!Utils.IsPlayerGameObject(other.gameObject))
            return;

        if (destroyOnTrigger)
            RemoveObstacle();

        PlayerManager.Instance.ResetPlayer();
    }

    private void RemoveObstacle()
    {
        AudioManager.Instance.PlaySFX(destructionClip, transform.position);

        Destroy(gameObject);
    }
}
