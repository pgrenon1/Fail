using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [ValidateInput("ValidateOnlyOneSpawn", "Only one SpawnPoint of this type is valid!")]
    public bool isEditorSpawnPoint = false;

    public bool ValidateOnlyOneSpawn(bool isEditorSpawnPoint)
    {
        var spawnPoints = FindObjectsOfType<SpawnPoint>();

        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint != this && spawnPoint.isEditorSpawnPoint == isEditorSpawnPoint)
            {
                return false;
            }
        }

        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "gizmo_figurine.png");
    }
}
