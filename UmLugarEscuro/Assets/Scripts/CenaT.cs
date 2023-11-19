using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaT : MonoBehaviour
{
    public string nomeDaCenaACarregar; // Nome da cena que você deseja carregar
    public float tempoDeEspera = 3.0f; // Tempo em segundos antes de carregar a próxima cena

    void Start()
    {
        // Inicia a contagem regressiva para carregar a próxima cena
        Time.timeScale = 1;
        Invoke("CarregarProximaCena", tempoDeEspera);
    }

    void CarregarProximaCena()
    {
        // Carrega a cena desejada
        SceneManager.LoadScene(nomeDaCenaACarregar);
    }
}
