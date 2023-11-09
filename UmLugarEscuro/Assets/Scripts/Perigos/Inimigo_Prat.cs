using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Prat : MonoBehaviour
{
    public Transform[] pontosDePatrulha; // Array de pontos de patrulha
    public float velocidade = 2.0f; // Velocidade do inimigo

    private int pontoAtual = 0; // Índice do ponto de patrulha atual
    private Vector3 direcao;

    void Start()
    {
        direcao = (pontosDePatrulha[pontoAtual].position - transform.position).normalized;
    }

    void Update()
    {
        // Move o inimigo em direção ao ponto de patrulha atual
        transform.position = Vector2.MoveTowards(transform.position, pontosDePatrulha[pontoAtual].position, velocidade * Time.deltaTime);

        // Calcula a direção do movimento
        direcao = (pontosDePatrulha[pontoAtual].position - transform.position).normalized;

        // Rotaciona o sprite do inimigo na direção do movimento
        if (direcao.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direcao.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        // Verifica se o inimigo atingiu o ponto de patrulha atual, se sim, avança para o próximo ponto
        if (Vector2.Distance(transform.position, pontosDePatrulha[pontoAtual].position) < 0.1f)
        {
            pontoAtual = (pontoAtual + 1) % pontosDePatrulha.Length;
        }
    }
}
