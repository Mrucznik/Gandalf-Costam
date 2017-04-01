using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{

    int jump2 = 0, floor = 0;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {

        if (Input.GetKeyDown("space") && ((floor == 1 || jump2 <= 1)))
        {
            rb.AddForce(new Vector2(0, 200f));
            floor = 0;
            jump2++;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        floor = 1;
        jump2 = 0;

    }
}
