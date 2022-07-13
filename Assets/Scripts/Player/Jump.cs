using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.PlayerLoop;

public class Jump : MonoBehaviour
{

    private MoveBehaviour _moveBehaviour;
    [SerializeField] private float _forzejump = 0.1f;
    private Rigidbody _rb;
    private float x, y;
    [SerializeField] private bool _tojump = false;


    public Boolean ToJump
    {
        get => _tojump;
        set => _tojump = value;
    }

    private float _velocityrotation = 0.5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _moveBehaviour = GetComponent<MoveBehaviour>();
        //_animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        // transform.Rotate(0, x * Time.deltaTime * _velocityrotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * _moveBehaviour.Velocity);
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (_tojump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(new Vector3(0, _forzejump, 0), ForceMode.Impulse);
                //animator.Playv animación Jump
            }
        }
        else
        {
            Fall();
        }

    }

    public void Fall()
    {
        //animaciones.
    }

}
