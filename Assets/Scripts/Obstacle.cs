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

        var player = PlayerManager.Instance.Player;

        player.PlayDeathFeedback(other.transform.position, Quaternion.LookRotation(other.transform.forward));

        LevelManager.Instance.RestartLevel();
    }

    private void RemoveObstacle()
    {
        AudioManager.Instance.PlaySFX(destructionClip, transform.position);

        Destroy(gameObject);
    }
}
