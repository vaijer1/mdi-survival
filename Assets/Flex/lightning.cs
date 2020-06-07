using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D physics;


    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        physics.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D thing)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        Destroy(gameObject);
        if (thing.CompareTag("EnemyG"))
        {
            thing.GetComponent<Ghost>().Damage(1);
        }
        if (thing.CompareTag("EnemyS"))
        {
            thing.GetComponent<Skeleton>().Damage(1);
        }
    }
}
