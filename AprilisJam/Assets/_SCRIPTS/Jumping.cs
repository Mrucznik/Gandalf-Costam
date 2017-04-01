using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{

    int jump2 = 0;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


    void Update()
    {

        if (Input.GetKeyDown("space") && (( grounded || jump2 <= 1)))
        {

            anim.SetBool("jump",true);
        
            rb.AddForce(new Vector2(0, 200f));
            jump2++;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        jump2 = 0;
        anim.SetBool("jump", false);

    }
}
