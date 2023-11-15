using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogo
{
    [SerializeField]
    private TextoDialogo[] _frases;

    [SerializeField] private string _nomeNpc;

    public TextoDialogo[] GetFrases()
    {
        return _frases;
    }

    public string GetNomeNPC()
    {
        return _nomeNpc;
    }
}
