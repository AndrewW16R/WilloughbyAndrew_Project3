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

    [Header("Trigger Filters")]
    [SerializeField]
    [Tooltip("The specific trigger object is inputed in Spawner script on the corresponding SpawnerTriggerVolume")]
    private bool _specificTriggerObject = false;
    [SerializeField]
    private LayerMask _layersToDetect = -1;

    [Header("Gizmo Settings")]
    [SerializeField]
    private bool _displayGizmos = false;
    [SerializeField]
    private bool _showOnlyWhileSelected = true;
    [SerializeField]
    private Color _gizmoColor = Color.green;

    public GameObject ObjectToSpawn => _objectToSpawn;
    public bool SpawnOnAwake => _spawnOnAwake;
    public bool SpecificTriggerObject => _specificTriggerObject;
    public LayerMask LayersToDetect => _layersToDetect;
    public bool DisplayGizmos => _displayGizmos;
    public bool ShowOnlyWhileSelected => _showOnlyWhileSelected;
    public Color GizmoColor => _gizmoColor;
}
