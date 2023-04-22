using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EndlessSpawnerData_", menuName = "SpawnData/EndlessSpawner")]

public class EndlessSpawnerData : ScriptableObject
{
    [Header("Spawner Settings")]
    [SerializeField]
    private GameObject _objectToSpawn = null;
    [SerializeField]
    [Tooltip("If enabled, the trigger will not need to be entered to start the spawning process")]
    private bool _spawnOnAwake;
}
