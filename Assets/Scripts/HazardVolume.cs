using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HazardVolume : MonoBehaviour
{
    [SerializeField] GameObject _playerObject;
    private GameObject _collisionObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _playerObject)
        {
            Debug.Log("Collision");
            Destroy(_playerObject);
        }
       
    }
}
