using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerForceShutoffTest : MonoBehaviour
{
    public UnityEvent OnQPress;
    [SerializeField] private bool _enableThisScript = false;

    // Update is called once per frame
    void Update()
    {
       

       if (Input.GetKeyDown(KeyCode.Q) && _enableThisScript == true)
        {
            OnQPress.Invoke();
        }
    }
}
