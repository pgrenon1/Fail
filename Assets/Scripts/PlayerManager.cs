using System;
using System.Collections;
using UnityEngine;

public class PlayerManager : OdinSerializedSingletonBehaviour<PlayerManager>
{
    public PlayerController playerPrefab;

    public PlayerController Player { get; private set; }

    public void CreatePlayerController(Vector3 position, Quaternion rotation)
    {
        Player = Instantiate(playerPrefab, position, rotation);
    }

    public void TogglePlayerActive(bool active)
    {
        if (active)
            Player.gameObject.SetActive(true);
        else
            Player.gameObject.SetActive(false);
    }

    public void TeleportToSpawnPoint()
    {
        Player.Rigidbody.velocity = Vector3.zero;

        var spawnPoint = GetSpawnPoint();
        if (spawnPoint != null)
        {
            Player.transform.position = spawnPoint.transform.position;
            Player.transform.rotation = spawnPoint.transform.rotation;
        }
        else
        {
            Debug.Log("No SpawnPoint found!");
        }
    }

    public void DestroyPlayer()
    {
        Destroy(Player.gameObject);
        Player = null;
    }

    public void SpawnPlayer()
    {
        CreatePlayerController(Vector3.zero, Quaternion.identity);

        TeleportToSpawnPoint();

        TogglePlayerActive(true);
    }

    private SpawnPoint GetSpawnPoint()
    {
        var spawnPoints = FindObjectsOfType<SpawnPoint>();
        SpawnPoint editorSpawnPoint = null;
        SpawnPoint nonEditorSpawnPoint = null;

        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint.isEditorSpawnPoint)
                editorSpawnPoint = spawnPoint;
            else
                nonEditorSpawnPoint = spawnPoint;
        }

#if UNITY_EDITOR
        if (editorSpawnPoint)
            return editorSpawnPoint;
        else
            return nonEditorSpawnPoint;
#else
        if (nonEditorSpawnPoint)
            return nonEditorSpawnPoint;
        else 
            return editorSpawnPoint;
#endif
    }

    public void ResetPlayer()
    {
        TogglePlayerActive(false);

        TeleportToSpawnPoint();

        Player.ResetCamera();

        TogglePlayerActive(true);

        Player.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        Player.visualsParent.SetActive(true);
    }
}
