using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoIA : MonoBehaviour
{
    public NavMeshAgent _ia;
    public float timeGuard = 2.0f;
    private float timer;
    public Transform[] points;
    private int netxPoint;
    [SerializeField] private bool talking = false;

    public bool Talking { get => talking; set => talking = value; }

    private void Start()
    {
        _ia = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (talking)
        {
            _ia.isStopped = true; ;
        }
        else
        {
            if (timer < timeGuard)
            {
                Guardia();
            }
            if (timer >= timeGuard)
            {
                Patrullar();
            }
        }

    }



    void Guardia()
    {
        timer = timer + 1 * Time.deltaTime;
    }

    void Patrullar()
    {
        _ia.isStopped = false;
        _ia.SetDestination(points[netxPoint].transform.position);
        Vector3 difPos = points[netxPoint].transform.position - this.transform.position;

        if (Mathf.Abs(difPos.x) < 0.1f && Mathf.Abs(difPos.z) < 0.1f)
        {
            timer = 0;
            if (netxPoint < points.Length - 1)
            {
                netxPoint++;
            }
            else if (netxPoint == points.Length - 1)
            {
                netxPoint = 0;
            }
        }
    }
}
