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
        move = Input.GetAxisRaw("Horizontal");
        animation.SetInteger("Animation", Convert.ToInt32(move));
        transform.Translate(transform.right * speed * move * Time.fixedDeltaTime);
    }


    private void Update()
    {
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