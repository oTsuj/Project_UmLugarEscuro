using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Prat : MonoBehaviour
{
    public Transform[] pontosDePatrulha;
    public float velocidade = 2.0f; 

    private int pontoAtual = 0;
    private Vector3 direcao;

    void Start()
    {
        direcao = (pontosDePatrulha[pontoAtual].position - transform.position).normalized;
    }

    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        transform.position = Vector2.MoveTowards(transform.position, pontosDePatrulha[pontoAtual].position, velocidade * Time.deltaTime);
        
        direcao = (pontosDePatrulha[pontoAtual].position - transform.position).normalized;
        
        if (direcao.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direcao.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        
        if (Vector2.Distance(transform.position, pontosDePatrulha[pontoAtual].position) < 0.1f)
        {
            pontoAtual = (pontoAtual + 1) % pontosDePatrulha.Length;
        } 
    }
}
