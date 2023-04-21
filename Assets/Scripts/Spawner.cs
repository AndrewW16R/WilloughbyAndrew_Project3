using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Spawner : MonoBehaviour
{
    private GameObject _spawnPointObject;
    private Transform _spawnPoint;

    [SerializeField] private SpawnerData _data;

    public SpawnerData Data => _data;

    private Collider _collider;
    private bool _alreadyEntered;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;

        _spawnPoint = GetComponentInChildren<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_data.OneShot == true && _alreadyEntered == true)
            return;

        if (_data.SpecificTriggerObject != null
            && other.gameObject != _data.SpecificTriggerObject)
            return;

        if (_data.LayersToDetect != (_data.LayersToDetect | (1 << other.gameObject.layer)))
            return;

        Debug.Log("Trigger Entered");
        StartCoroutine(EnableSpawner());
        _alreadyEntered = true;

    }

    public IEnumerator EnableSpawner()
    {
        int objectsSpawned = 0;

        if(_data.ObjectToSpawn != null)
        {
            while(objectsSpawned < _data.AmountToSpawn)
            {
                Instantiate(_data.ObjectToSpawn, _spawnPoint.position, _spawnPoint.rotation);
                yield return new WaitForSeconds(_data.TimeBetweenEachSpawn);
                objectsSpawned = objectsSpawned + 1;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (_data.DisplayGizmos == false)
            return;
        if (_data.ShowOnlyWhileSelected == true)
            return;

        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }

        Gizmos.color = _data.GizmoColor;
        Gizmos.DrawCube(transform.position, _collider.bounds.size);
    }

    private void OnDrawGizmosSelected()
    {
        if (_data.DisplayGizmos == false)
            return;
        if (_data.ShowOnlyWhileSelected == false)
            return;

        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }

        Gizmos.color = _data.GizmoColor;
        Gizmos.DrawCube(transform.position, _collider.bounds.size);
    }
}
