using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    PlayerCapsule _playerObject;
    private NavMeshAgent _agent;
    Transform _targetPosition;
    

    // Start is called before the first frame update
    void Awake()
    {
        _playerObject = FindObjectOfType<PlayerCapsule>();

        //_targetPosition = _playerObject.transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (_playerObject != null)
        {
            _targetPosition = _playerObject.transform;
            Debug.Log(_targetPosition.position);
            _agent.destination = _targetPosition.position;
        }
    }

}
