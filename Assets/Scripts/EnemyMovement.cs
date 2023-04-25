using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject _playerObject;
    private NavMeshAgent _agent;
    Transform _targetPosition;

    // Start is called before the first frame update
    void Awake()
    {
        _targetPosition = _playerObject.transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        _agent.destination = _targetPosition.position;
    }

}
