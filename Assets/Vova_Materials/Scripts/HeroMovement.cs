using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float move;
    public float HeroSpeed = 4f;
    public float jumpSpeed = 7f;
    public bool Ground = false;
    public Transform fetPosition;
    public float fetPosRadius = 0f;
    public LayerMask whatGround;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * HeroSpeed, rb.velocity.y);
        Flip();
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("Speed", Mathf.RoundToInt(move));
            
        }
    }
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        Ground = Physics2D.OverlapCircle(fetPosition.position, fetPosRadius, whatGround);
        if (!Input.GetKeyDown(KeyCode.Space) && Ground == true)
        {
            anim.SetBool("jump", false);
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && Ground == true)
        {
            Jump();
            anim.SetBool("jump", true);
        }

    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
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
