using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuedaEspinhos : MonoBehaviour
{
    private Vector2 originalPosition;
    private Rigidbody2D rb;
    private float cont;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = rb.position;
        rb.bodyType = RigidbodyType2D.Static; // Espinhos não caem até serem ativados
    }

    private void Update()
    {
        
    }

    public void DropThorns()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        cont += Time.deltaTime;
        if (cont == 3f)
        {
            DestroyThorns();
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            DestroyThorns();
        }
    }*/

    private void DestroyThorns()
    {
        rb.bodyType = RigidbodyType2D.Static;
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false); // Desativa os espinhos para simular a destruição

        Invoke(nameof(ResetPosition), 3f); // Agenda o método ResetPosition() para ser chamado após 3 segundos
    }

    private void ResetPosition()
    {
        gameObject.SetActive(true); // Reativa os espinhos
        rb.position = originalPosition;
    }
}

