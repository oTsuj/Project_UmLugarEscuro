using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) // Verifica se o objeto colidiu com o player (você pode ajustar a tag do jogador conforme necessário)
            {
                Destroy(gameObject); // Destruir o objeto atual (o que possui esse script)
            }
        }
}
