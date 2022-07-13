using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private MoveBehaviour _moveBehaviour;

    void Start()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _moveBehaviour.moveHorizontalX(-_moveBehaviour.Velocity);
        } else if (Input.GetKey(KeyCode.S))
        {
            _moveBehaviour.moveHorizontalX(_moveBehaviour.Velocity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveBehaviour.moveHorizontalZ(-_moveBehaviour.Velocity);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _moveBehaviour.moveHorizontalZ(_moveBehaviour.Velocity);
        }
    }
}
