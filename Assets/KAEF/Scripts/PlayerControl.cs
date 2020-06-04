using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    float speed = 4f;
    float move;
    public float JumpForce;
    private bool FaceR = true;

    Rigidbody2D rb;
    Animator animation;

    private bool isGrounded;
    public Transform fetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float health;
    public Text hp;
    public GameObject panel;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (FaceR && move < 0)
        {
            FaceR = !FaceR;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (!FaceR && move > 0)
        {
            FaceR = !FaceR;
            transform.Rotate(0f, 180f, 0f);
        }
        animation.SetInteger("Speed", Convert.ToInt32(move));
    }


    private void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        hp.text = health.ToString();
        isGrounded = Physics2D.OverlapCircle(fetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * JumpForce;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            panel.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }


    void Jump()
    {
        rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }
}