using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerData_", menuName = "SpawnData/Spawner")]

public class SpawnerData : ScriptableObject
{
    [Header("Spawner Settings")]
    [SerializeField]
    private GameObject _objectToSpawn = null;

    [SerializeField]
    private int _amountToSpawn =   0;

    [SerializeField]
    private float _timeBetweenEachSpawn = 0;


    [Header("Trigger Settings")]
    [SerializeField]
    private bool _oneShot = false;

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
    public int AmountToSpawn => _amountToSpawn;
    public float TimeBetweenEachSpawn => _timeBetweenEachSpawn;
    public bool OneShot => _oneShot;
    public bool SpecificTriggerObject => _specificTriggerObject;
    public LayerMask LayersToDetect => _layersToDetect;
    public bool DisplayGizmos => _displayGizmos;
    public bool ShowOnlyWhileSelected => _showOnlyWhileSelected;
    public Color GizmoColor => _gizmoColor;
}
