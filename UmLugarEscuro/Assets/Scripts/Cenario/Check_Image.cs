using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Image : MonoBehaviour
{
    
    private bool coletado = false;
    public Sprite checkpointColetadoSprite;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !coletado)
        {
            ColetarCheckpoint();
        }
    }
    void ColetarCheckpoint()
    {
        coletado = true;
        // Altera o sprite do checkpoint para o sprite coletado
        GetComponent<SpriteRenderer>().sprite = checkpointColetadoSprite;
    }
}
