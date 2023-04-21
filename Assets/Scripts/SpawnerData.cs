using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerData : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField]
    private GameObject _objectToSpawn;

    [SerializeField]
    private int _amountToSpawn;

    [SerializeField]
    private float _timeBetweenEachSpawn;


    [Header("Trigger Settings")]
    [SerializeField]
    private bool _oneShot;
}
