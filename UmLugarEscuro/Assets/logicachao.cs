using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicachao : MonoBehaviour
{

    public GameObject player;

    public bool isground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.GetComponent<_PlayerController>().isgrounded = true;
            isground = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.GetComponent<_PlayerController>().isgrounded = false;
            isground = false;
        }
    }
}
