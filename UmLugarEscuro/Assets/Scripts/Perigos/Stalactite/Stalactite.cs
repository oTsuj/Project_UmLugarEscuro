using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{

    private BoxCollider2D bc2d;
    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(bc2d);
            Destroy(gameObject, 0.7f);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(bc2d);
            Destroy(gameObject, 0.2f);
        }
    }
}
