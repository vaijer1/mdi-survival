using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    private float HeroSpeed = 3f;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetInteger("anim_state", 0);
        }
        else
        {
            Flip();
            anim.SetInteger("anim_state", 1);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * HeroSpeed, rb.velocity.y);
    }
    void Jump()
    {
        rb.AddForce(transform.up * 6f, ForceMode2D.Impulse);
    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
