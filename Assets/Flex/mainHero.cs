using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainHero : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D physics;

    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        physics.MovePosition(physics.position + Vector2.right * x * speed * Time.deltaTime);
    }
}
