using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraVolume : MonoBehaviour
{
    public CinemachineVirtualCamera cameraToActivate;

    private void OnTriggerStay(Collider other)
    {
        if (!Utils.IsPlayerGameObject(other.gameObject))
            return;

        cameraToActivate.Priority = 11;
    }

    private void FixedUpdate()
    {
        cameraToActivate.Priority = 0;
    }
}
