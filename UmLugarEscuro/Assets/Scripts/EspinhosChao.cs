using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhosChao : MonoBehaviour
{
    public float impulsoMagnitude = 5f; // A magnitude da impulsão contrária
    public Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObjetoColisao"))
        {
            // Calcular a direção da impulsão contrária
            Vector2 direcaoImpulsao = -(collision.contacts[0].normal);

            // Aplicar a impulsão contrária
            playerRigidbody.AddForce(direcaoImpulsao * impulsoMagnitude, ForceMode2D.Impulse);
        }
    }
}
