using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomController : MonoBehaviour
{
    public float zoomedOrthoSize = 8f; // Tamanho do zoom
    public float normalOrthoSize = 5f; // Tamanho normal
    public float zoomSpeed = 5f; // Velocidade de zoom

    private CinemachineVirtualCamera virtualCamera;
    private float targetOrthoSize;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        targetOrthoSize = normalOrthoSize; // Começa com o tamanho normal
        virtualCamera.m_Lens.OrthographicSize = targetOrthoSize;
    }

    private void Update()
    {
        // Verifica se o botão "Z" está sendo pressionado
        if (Input.GetKey(KeyCode.Z))
        {
            // Se o botão "Z" está pressionado, aumenta o zoom gradualmente
            targetOrthoSize = zoomedOrthoSize;
        }
        else
        {
            // Se o botão "Z" não está pressionado, retorna ao tamanho normal gradualmente
            targetOrthoSize = normalOrthoSize;
        }

        // Interpola suavemente o Ortho Size da câmera para o tamanho de destino
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetOrthoSize, Time.deltaTime * zoomSpeed);
    }
}

