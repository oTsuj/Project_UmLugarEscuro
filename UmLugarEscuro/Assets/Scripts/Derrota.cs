using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{
    public string _Menu;
    public string _CenaAtual; 
    
    public void Reinicar()
    {
        SceneManager.LoadScene(_CenaAtual);
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene(_Menu);
    }
}
