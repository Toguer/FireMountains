using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
       player= GameObject.FindGameObjectsWithTag("MainCamera")[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
