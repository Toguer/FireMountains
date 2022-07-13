using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterJump : MonoBehaviour
{
    //private Jump _jump;
    public Jump jump;

    //marranero
    private void Start()
    {
        //_jump = GetComponent<Jump>();
    }

    private void OnTriggerStay(Collider other)
    {
        //_jump.ToJump = true;
        jump.ToJump = true;
    }



     private void OnTriggerExit(Collider other)
      {
          //_jump.ToJump = false;
          jump.ToJump = false;
      }
    
    private void OnCollisionExit(Collision collision)
    {
        jump.ToJump = false;
    }
}
