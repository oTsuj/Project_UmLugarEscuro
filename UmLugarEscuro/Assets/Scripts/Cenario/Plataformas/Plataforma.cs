using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform startPoint; 
    public Transform endPoint;   
    public float speed = 2f;     

    private Vector3 targetPosition;
    private bool movingToEndPoint = true;

    void Start()
    {
        targetPosition = endPoint.position;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (movingToEndPoint)
            {
                targetPosition = startPoint.position;
            }
            else
            {
                targetPosition = endPoint.position;
            }
            
            movingToEndPoint = !movingToEndPoint;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
