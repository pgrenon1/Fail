using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerSource))]
public class Obstacle : MonoBehaviour
{
    public ParticleSystem destructionVFX;
    public AudioClip destructionClip;

    private TriggerSource _triggerSource;

    private void Start()
    {
        _triggerSource = GetComponent<TriggerSource>();

        _triggerSource.OnSourceTriggerEnter += TriggerSource_OnSourceTriggerEnter;
    }

    private void TriggerSource_OnSourceTriggerEnter(Collider other)
    {
        if (!Utils.IsPlayerGameObject(other.gameObject))
            return;

        RemoveObstacle();

        PlayerManager.Instance.ResetPlayer();
    }

    private void RemoveObstacle()
    {
        Destroy(gameObject);
    }
}
