using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TextoDialogo
{
    [SerializeField] 
    [TextArea(1,3)]
    private string _frase;
    
    [SerializeField] private string _btnContinuar;

    public string GetFrase()
    {
        return _frase;
    }

    public string GetBotaoContinuar()
    {
        return _btnContinuar;
    }
}
