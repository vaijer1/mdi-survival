using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
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
        if (thing.gameObject.CompareTag("Player"))
            thing.gameObject.GetComponent<MainHero>().Damage(1);

    }
}
