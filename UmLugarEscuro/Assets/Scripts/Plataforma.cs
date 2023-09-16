using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform startPoint; // Ponto inicial da plataforma
    public Transform endPoint;   // Ponto final da plataforma
    public float speed = 2f;     // Velocidade de movimento da plataforma

    private Vector3 targetPosition;
    private bool movingToEndPoint = true;

    void Start()
    {
        targetPosition = endPoint.position;
    }

    void Update()
    {
        // Move a plataforma em direção ao ponto-alvo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Verifica se a plataforma chegou ao ponto-alvo
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Alterna o ponto-alvo
            if (movingToEndPoint)
            {
                targetPosition = startPoint.position;
            }
            else
            {
                targetPosition = endPoint.position;
            }

            // Inverte a direção de movimento
            movingToEndPoint = !movingToEndPoint;
        }
    }
}
