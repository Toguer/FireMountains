using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour
{

    private int calc_drop = 0;
    public int prob1=25, prob2=50, prob3=101;

    public static DropSystem dropSystem;


    private void Awake()
    {
        if (dropSystem == null)
        {
            dropSystem = this;
        }
        else if (dropSystem != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public int CalculateLoot2()
    {
        //sistema de sacar monedas y billetes
        calc_drop = Random.Range(0, 101);

        if (calc_drop >= 0 && calc_drop <= prob1)
        {
            //0 DROP
            Debug.Log("Return 0");
            return 0;
        }
        else if (calc_drop >= prob1+1 && calc_drop <= prob2+1)
        {
            //1 DROP
            Debug.Log("Return 1");
            return 1;
        }
        else if (calc_drop >= prob2+1 && calc_drop <= prob3)
        {
            //2 DROP
            //_dropnum += 2;
            Debug.Log("Return 2");
            return 2;
        }
        return 1;
    }

    //CON EL DROP NUM SUMARLO AL MONEY
}
