using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerTracker : MonoBehaviour
{
    public float maxDistanceFromLastWaypoint;

    private CinemachineSmoothPath _track;

    private PlayerController Player { get { return PlayerManager.Instance.Player; } }
    private List<Vector3> _waypoints = new List<Vector3>();
    private Vector3 originalFreelookCamOffset;

    private void Awake()
    {
        _track = GetComponent<CinemachineSmoothPath>();

        LevelManager.Instance.OnLevelStartedOrRestarted += LevelManager_OnLevelStartedOrRestarted;
    }

    private void LevelManager_OnLevelStartedOrRestarted()
    {
        originalFreelookCamOffset = PlayerManager.Instance.Player.CinemachineVirtualCamera.transform.position - PlayerManager.Instance.Player.transform.position;

        AddWayPoint(PlayerManager.Instance.Player.CinemachineVirtualCamera.transform.position);
    }

    private void Update()
    {
        if (LevelManager.Instance.CurrentLevel.IsStarted)
        {
            var delta = Player.transform.position - _track.m_Waypoints[_track.m_Waypoints.Length - 1].position;
            if (delta.magnitude > maxDistanceFromLastWaypoint)
            {
                AddWayPoint(Player.transform.position + originalFreelookCamOffset);
            }
        }
    }

    //public void MakeTrack()
    //{
    //    AddWayPoint(Player.transform.position + originalFreelookCamOffset);

    //    _track.m_Waypoints = new CinemachineSmoothPath.Waypoint[_waypoints.Count];

    //    for (int i = 0; i < _track.m_Waypoints.Length; i++)
    //    {
    //        var newPoint = new CinemachineSmoothPath.Waypoint();
    //        newPoint.position = _waypoints[i];
    //        _track.m_Waypoints[i] = newPoint;
    //    }
    //}

    private void AddWayPoint(Vector3 position)
    {
        var newSize = _track.m_Waypoints.Length + 1;
        Array.Resize(ref _track.m_Waypoints, newSize);

        var newWayPoint = new CinemachineSmoothPath.Waypoint();
        newWayPoint.position = position;

        _track.m_Waypoints[newSize - 1] = newWayPoint;
    }

    public void ClearTrack()
    {
        _track.m_Waypoints = new CinemachineSmoothPath.Waypoint[0];
        _waypoints = new List<Vector3>();
    }
}
