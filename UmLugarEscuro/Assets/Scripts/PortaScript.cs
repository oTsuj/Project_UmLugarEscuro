using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaScript : MonoBehaviour
{
    // Nome da cena para a qual você deseja redirecionar
    public string cenaDestino;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (collision.CompareTag("Player"))
        {
            // Redireciona para a cena de destino
            SceneManager.LoadScene(cenaDestino);
        }
    }
}
