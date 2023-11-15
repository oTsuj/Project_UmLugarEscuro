using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinInimigo : MonoBehaviour
{
    public float amplitude = 1.0f; // Amplitude da variação
    public float velocidade = 2.0f; // Velocidade da variação
    private float tempo = 0.0f;

    void Update()
    {
        tempo += Time.deltaTime;
        float variacaoAltura = amplitude * Mathf.Sin(velocidade * tempo);

        // Aplica a variação na posição Y do objeto
        transform.position = new Vector3(transform.position.x, variacaoAltura, transform.position.z);
    }
}
