using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoEspinhos : MonoBehaviour
{
    public QuedaEspinhos thornFallScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            thornFallScript.DropThorns();
        }
    }
}

