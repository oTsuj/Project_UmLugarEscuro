using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    private bool isPaused;

    public GameObject _Painel;

    public string cena;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Pausar();
    }

    public void Pausar()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Desabilitar();
            }
            else
            {
                Habilitar();
            }
        }
    }

    public void Desabilitar()
    {
        _Painel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Habilitar()
    {
        _Painel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene(cena);
    }
}
