using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFall : MonoBehaviour
{
   public float fallDelay = 2f; // Tempo (em segundos) que a plataforma espera para cair após o jogador pisar nela.
       public float fallSpeed = 5f; // Velocidade de queda da plataforma.
   
       private Rigidbody2D rb;
       private bool isFalling = false;
       private Vector2 originalPosition;
   
       void Start()
       {
           rb = GetComponent<Rigidbody2D>();
           originalPosition = rb.position;
       }
   
       void OnCollisionEnter2D(Collision2D collision)
       {
           if (collision.gameObject.CompareTag("Player") && !isFalling)
           {
               Invoke("Fall", fallDelay);
           }
       }
   
       void Fall()
       {
           isFalling = true;
           rb.bodyType = RigidbodyType2D.Dynamic;
           rb.velocity = new Vector2(0f, -fallSpeed);
       }
   
       void ResetPlatform()
       {
           rb.position = originalPosition;
           rb.bodyType = RigidbodyType2D.Static;
           isFalling = false;
       }
   
       void OnTriggerEnter2D(Collider2D other)
       {
           // Reinicie a plataforma se o jogador voltar para ela enquanto ela está caindo.
           if (other.CompareTag("Player") && isFalling)
           {
               ResetPlatform();
           }
       }
   
       // Pode ser necessário ajustar a detecção do chão ou outros comportamentos de reset
       // dependendo da mecânica do seu jogo.
}
