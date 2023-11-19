using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaScript : MonoBehaviour
{
    private float _TempoDeEspera = 0.2f;
    public string cenaDestino;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(EsperaCena());
        }
    }

    IEnumerator EsperaCena()
    {
        yield return new WaitForSeconds(_TempoDeEspera);
        SceneManager.LoadScene(cenaDestino); 
    }
}
