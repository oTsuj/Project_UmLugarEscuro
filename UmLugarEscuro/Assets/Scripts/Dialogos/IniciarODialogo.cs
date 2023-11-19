using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarODialogo : MonoBehaviour
{

    private bool Dialog = false;
    public InicializadorDeDialogo iniciar;
    public GameObject exclamacao;

    private void Start()
    {
        exclamacao.SetActive(false);
    }

    private void Update()
    {
        if (Dialog == true && Input.GetKeyDown(KeyCode.U))
        {
            iniciar.Inicializa();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Dialog = true;
            exclamacao.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Dialog = false;
            exclamacao.SetActive(false);
        }
    }
}
