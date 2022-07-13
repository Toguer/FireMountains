using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMovement : MonoBehaviour
{

    public Transform[] points;
    public NavMeshAgent _ia;

    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        _ia = GetComponent<NavMeshAgent>();
        GotoNextPoint();
        //StartCoroutine(GotoNextPoint2());
    }

    //RECORRER PUNTOS
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        _ia.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        transform.LookAt(points[destPoint].position);

    }
    /*
    IEnumerator GotoNextPoint2()
    {
        _ia.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        transform.LookAt(points[destPoint].position);

        yield return new WaitForSeconds(4f);
    }*/


    void Update()
    {

        if (_ia.remainingDistance < 0.2f)
            GotoNextPoint();
    }
}
