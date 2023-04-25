using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        LoadCheck();
    }

    public void LoadCheck()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Demo1");
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Demo2");
        }

    }

}
