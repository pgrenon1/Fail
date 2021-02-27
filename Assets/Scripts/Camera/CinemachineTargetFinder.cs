using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CinemachineTargetFinder : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

        SceneManager.sceneLoaded += SceneManager_SceneLoaded;
    }

    private void SceneManager_SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TryFindTarget();
    }

    private void TryFindTarget()
    {
        var targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        if (targetGroup)
        {
            _cinemachineVirtualCamera.Follow = targetGroup.transform;
            _cinemachineVirtualCamera.LookAt = targetGroup.transform;
        }
    }
}
