using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHero : MonoBehaviour
{
    public float speed = 10f;
    public float height = 4500f;
    public float hp = 10;
    bool facingRight = true;
    Rigidbody2D physics;
    bool onGround = true;
    bool onTrap = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public LayerMask whatIsTrap;

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
        onTrap = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsTrap);
        if (onTrap)
            Damage(hp);
    }

    void Flip(float moveX)
    {
        if (moveX < 0 && facingRight || moveX > 0 && !facingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = !facingRight;
        }
    }

    public void Damage (float damage)
    {
        hp -= damage;
        if (hp == 0)
            SceneManager.LoadScene(0);
    }
}