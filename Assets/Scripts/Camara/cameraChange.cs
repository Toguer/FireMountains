using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour
{

    public CinemachineDollyCart dollyCart;
    public CinemachineVirtualCamera _cinemachineCamera;
    public CinemachineSmoothPath _cinePath;
    public GameObject lookAtGameObject;
    public GameObject FollowGameObject;
    public GameObject maincamera;
    [SerializeField] private float cameraSpeed;

    void Start()
    {
        dollyCart.m_Speed = 0;
    }

    private void endStart()
    {
        //  _cinemachineCamera.DestroyCinemachineComponent<CinemachineTransposer>();
        //  _cinemachineCamera.AddCinemachineComponent<CinemachineTrackedDolly>().m_Path = _cinePath;
        _cinePath.m_Waypoints[0].position = maincamera.transform.position;
        dollyCart.m_Speed = cameraSpeed;
        _cinemachineCamera.LookAt = lookAtGameObject.transform;
        _cinemachineCamera.Follow = FollowGameObject.transform;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endStart();
        }
    }
}
