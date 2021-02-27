using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : OdinSerializedSingletonBehaviour<CameraManager>
{
    public CinemachineBrain PlayerCinemachineBrain { get; set; }

    private List<CinemachineVirtualCamera> _cinemachineVirtualCameras = new List<CinemachineVirtualCamera>();

    protected override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += SceneManager_SceneLoaded;
    }

    private void SceneManager_SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TryAddCameras();
    }

    private void TryAddCameras()
    {
        var allCameras = FindObjectsOfType<CinemachineVirtualCamera>();
        foreach (var camera in allCameras)
        {
            _cinemachineVirtualCameras.AddUnique(camera);
        }
    }

    public void ActivateCamera(CinemachineVirtualCamera cameraToActivate)
    {
        PlayerCinemachineBrain.ActiveVirtualCamera.Priority = 0;
        cameraToActivate.Priority = 10;
    }
}
