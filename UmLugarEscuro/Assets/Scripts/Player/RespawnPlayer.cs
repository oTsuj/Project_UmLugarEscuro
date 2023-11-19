using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private Vector3 respawnPoint;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbPlayer;
    public ParticleSystem part;
    public AudioSource somMorte;
    public AudioSource somCheck;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        respawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fall")
        {
            Die();
        }

        else if (col.tag == "Checkpoint")
        {
            somCheck.Play();
            respawnPoint = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fall")
        {
            Die();
        }
    }

    private void Die()
    {
        somMorte.Play();
        ParticleSystem partExplosaoPlayer = Instantiate(this.part, this.transform.position, quaternion.identity);
        Destroy(partExplosaoPlayer.gameObject, 0.5f);
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        spriteRenderer.enabled = false;
        rbPlayer.simulated = false;
        rbPlayer.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = respawnPoint;
        spriteRenderer.enabled = true;
        rbPlayer.simulated = true;
        spriteRenderer.enabled = true;
    }

}
