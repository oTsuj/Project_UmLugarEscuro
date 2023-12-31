using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFall : MonoBehaviour
{
   public float fallDelay = 2f;
       public float fallSpeed = 5f; 
   
       private Rigidbody2D rb;
       private bool isFalling = false;
       private Vector2 originalPosition;
       private AudioSource audio;

       private void Awake()
       {
           audio = GetComponent<AudioSource>();
       }

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
           audio.Play();
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
           if (other.CompareTag("Reset") && isFalling)
           {
               ResetPlatform();
           }
       }
}
