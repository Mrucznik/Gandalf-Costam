using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{

    int jump2 = 0, floor = 0;
    public Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        if (Input.GetKeyDown("space") && ((floor == 1 || jump2 <= 1)))
        {

            anim.SetBool("jump",true);
        
            rb.AddForce(new Vector2(0, 200f));
            floor = 0;
            jump2++;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        floor = 1;
        jump2 = 0;
        anim.SetBool("jump", false);

    }
}
