using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerForceShutoffTest : MonoBehaviour
{
    public UnityEvent OnQPress;

    // Update is called once per frame
    void Update()
    {
       

       if (Input.GetKeyDown(KeyCode.Q))
        {
            OnQPress.Invoke();
        }
    }
}
