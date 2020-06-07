using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class lightning : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D physics;


    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        physics.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D thing)
    {
        Destroy(gameObject);
        if (thing.CompareTag("Enemy"))
        {
            Destroy(thing.gameObject);
        }
    }
}
