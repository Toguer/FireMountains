using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mapUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            openCloseMap();
        }
    }



    void openCloseMap()
    {
        if (mapUI.activeInHierarchy)
        {
            mapUI.SetActive(false);
        }
        else
        {
            mapUI.SetActive(true);
        }
    }
}
