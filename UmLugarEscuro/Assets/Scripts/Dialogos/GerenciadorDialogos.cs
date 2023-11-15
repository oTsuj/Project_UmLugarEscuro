using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GerenciadorDialogos : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nomeNPC;
    [SerializeField]
    private TextMeshProUGUI _texto;
    [SerializeField]
    private TextMeshProUGUI _btnContinua;

    [SerializeField] private GameObject _caixaDialogo;

    private int _contador = 0;
    private Dialogo _dialogoAtual;

    public void Inicializa(Dialogo dialogo)
    {
        _contador = 0;
        _dialogoAtual = dialogo;
        ProximaFrase();
    }

    public void ProximaFrase()
    {
        if (_dialogoAtual == null)
            return;
        if (_contador == _dialogoAtual.GetFrases().Length)
        {
            _caixaDialogo.gameObject.SetActive(false);
            _dialogoAtual = null;
            _contador = 0;
            return;
        }
        
        _nomeNPC.text = _dialogoAtual.GetNomeNPC();
        _texto.text = _dialogoAtual.GetFrases()[_contador].GetFrase();
        _btnContinua.text = _dialogoAtual.GetFrases()[_contador].GetBotaoContinuar();
        _caixaDialogo.gameObject.SetActive(true);
        _contador++;
    }
}
