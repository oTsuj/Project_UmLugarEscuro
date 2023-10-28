using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteCollider : MonoBehaviour
{
    private BoxCollider2D bc2d;

    public Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy((bc2d));
            Destroy(this);
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
