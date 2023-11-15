using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{

    [SerializeField] string nomeLevel;
    [SerializeField] private GameObject painelInicial;
    private float tempoDeEspera = 0.6f;
    
    public void Jogar()
    {
        StartCoroutine(EsperaJogar());
    }

    IEnumerator EsperaJogar()
    {
        yield return new WaitForSeconds(tempoDeEspera);
        SceneManager.LoadScene(nomeLevel);
    }
    
    IEnumerator EsperaSair()
    {
        yield return new WaitForSeconds(tempoDeEspera);
        Application.Quit();
    }

    public void FecharJogo()
    {
        StartCoroutine(EsperaSair());
    }
}
