using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomController : MonoBehaviour
{
    public float zoomedOrthoSize = 8f; 
    public float normalOrthoSize = 5f; 
    public float zoomSpeed = 5f; 

    private CinemachineVirtualCamera virtualCamera;
    private float targetOrthoSize;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        targetOrthoSize = normalOrthoSize; 
        virtualCamera.m_Lens.OrthographicSize = targetOrthoSize;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            targetOrthoSize = zoomedOrthoSize;
        }
        else
        {
            targetOrthoSize = normalOrthoSize;
        }
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetOrthoSize, Time.deltaTime * zoomSpeed);
    }
}

