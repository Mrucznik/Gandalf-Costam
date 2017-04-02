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
    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private bool isGrounded = false;


    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down * 0.05f, Vector2.down, .01f);
        isGrounded = (hit.collider != null && hit.collider.gameObject.layer == 8);
        if (isGrounded)
        {
            jump2 = 0;
        }
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (( isGrounded || jump2 < 1 )))
        {
            anim.SetBool("jump",true);
        
            rb.AddForce(new Vector2(0, jumpForce));
            jump2++;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        anim.SetBool("jump", false);

    }
}
