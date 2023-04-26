using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPointObject;
    private Transform _spawnPoint;

    [SerializeField] private SpawnerData _data;

    [SerializeField] private GameObject _specificTriggerObject;

    public SpawnerData Data => _data;

    private Collider _collider;
    private bool _alreadyEntered;
    private bool _forceShutoff;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;

        if (_spawnPointObject != null)
        {
            _spawnPoint = _spawnPointObject.GetComponent<Transform>();
        }

    }

    private void Start()
    {
        if (_data != null)
        {
            _data.SetOneShotTrue();

            if (_data.SpawnOnAwake == true)
            {
                _alreadyEntered = true;

                if (_data.EndlessSpawning == true)
                {
                    StartCoroutine(EnableEndlessSpawner());
                }
                else
                {
                    StartCoroutine(EnableSpawner());
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_data != null)
        {
            if (_data.OneShot == true && _alreadyEntered == true)
                return;

            if (_data.SpecificTriggerObject == true
                && other.gameObject != _specificTriggerObject)
                return;

            if (_data.LayersToDetect != (_data.LayersToDetect | (1 << other.gameObject.layer)))
                return;

            if (_data.EndlessSpawning == true)
            {
                _alreadyEntered = true;
                Debug.Log("Spawner Trigger Entered");
                StartCoroutine(EnableEndlessSpawner());
            }
            else
            {
                Debug.Log("Spawner Trigger Entered");
                StartCoroutine(EnableSpawner());
                _alreadyEntered = true;
            }
        }
        

    }

    public IEnumerator EnableSpawner()
    {
        if (_data != null)
        {
            int objectsSpawned = 0;

            if (_data.ObjectToSpawn != null && _data.EndlessSpawning == false)
            {
                yield return new WaitForSeconds(_data.SpawnerStartDelay);
                while (objectsSpawned < _data.AmountToSpawn)
                {
                    Instantiate(_data.ObjectToSpawn, _spawnPoint.position, _spawnPoint.rotation);
                    yield return new WaitForSeconds(_data.TimeBetweenEachSpawn);
                    objectsSpawned = objectsSpawned + 1;
                }
            }
        }
    }

    public IEnumerator EnableEndlessSpawner()
    {
        if (_data != null)
        {
            if (_data.ObjectToSpawn != null && _data.EndlessSpawning == true)
            {
                while (_forceShutoff == false)
                {
                    Instantiate(_data.ObjectToSpawn, _spawnPoint.position, _spawnPoint.rotation);
                    yield return new WaitForSeconds(_data.TimeBetweenEachSpawn);
                }
            }
        }
    }

    public void ForceShutoffSpawner()
    {
        _forceShutoff = true;
    }


    private void OnDrawGizmos()
    {
        if (_data != null)
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
            DrawSpawnerConnection();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_data != null)
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
            DrawSpawnerConnection();
        }
    }

    private void DrawSpawnerConnection()
    {
        if (_data != null && _spawnPointObject != null)
        {
            Gizmos.color = Color.cyan;
            Vector3 TriggerPosition = gameObject.transform.position;
            Vector3 SpawnerPosition = _spawnPointObject.transform.position;
            Gizmos.DrawLine(TriggerPosition, SpawnerPosition);
        }

    }
}
