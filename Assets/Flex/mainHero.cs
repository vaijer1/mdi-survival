using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainHero : MonoBehaviour
{
    public float speed = 10f;
    public float height = 4500f;
    bool facingRight = true;
    Rigidbody2D physics;
    bool onGround = true;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && onGround)
        {
            physics.AddForce(Vector2.up * height);
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        Flip(x);
        physics.MovePosition(physics.position + Vector2.right * x * speed * Time.deltaTime);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void Flip(float moveX)
    {
        if (moveX < 0 && facingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = !facingRight;
        }
        else if (moveX > 0 && !facingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = !facingRight;
        }
    }
}