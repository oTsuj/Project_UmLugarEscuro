using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private Vector3 respawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fall")
        {
            transform.position = respawnPoint;
        }
        
        else if (col.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}
