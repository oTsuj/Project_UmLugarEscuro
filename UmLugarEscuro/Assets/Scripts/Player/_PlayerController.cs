using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerController : MonoBehaviour
{

    public Rigidbody2D rig;
    public Transform posicaoDoPe;

    public LayerMask ground;

    private float direcao;

    [SerializeField] private float velocidade;
    [SerializeField] private float jumpforce;
    public int numPulos = 0;

    public bool isgrounded;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CheckInput();
    }

    private void FixedUpdate()
    {
        Move();
        CheckInput();
    }

    void CheckInput()
    {
        if (isgrounded)
        {
            numPulos = 2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && numPulos > 0)
        {
            Jump();
        }
    }

private void VerificarChao()
    {
        //cria um circulo na posicao do pe
        //testa colisao na mascara do chao
    }
    
    private void Move()
    {
        //movimentar para os lados
        direcao = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(direcao * velocidade, rig.velocity.y); 
    }

    private void Jump()
    {
        numPulos--;
        rig.velocity = Vector2.up * jumpforce;
    }
}
