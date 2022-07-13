using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{

    public GameObject mapUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!mapUI.activeInHierarchy)
            {
                mapUI.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                mapUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
