using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativarImagem : MonoBehaviour
{
    public GameObject Imagem;
    void Start()
    {
        
    }

    public void Desativar()
    {
        Imagem.SetActive(false);
    }
}
