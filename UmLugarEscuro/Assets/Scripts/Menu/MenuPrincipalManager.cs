using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{

    [SerializeField] string nomeLevel;
    [SerializeField] private GameObject painelInicial;
    [SerializeField] private GameObject painelOpcoes;
    
    public void Jogar()
    {
        SceneManager.LoadScene(nomeLevel);
    }

    public void AbirCreditos()
    {
        painelInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharCreditos()
    {
        painelInicial.SetActive(true);
        painelOpcoes.SetActive(false); 
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
