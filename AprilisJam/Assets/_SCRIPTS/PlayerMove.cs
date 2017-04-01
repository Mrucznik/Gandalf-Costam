using System;
using UnityEngine;
using System.Collections;
using System.Security;
using System.Timers;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private int moveiterator = 0;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Gift")
        {
            Destroy(col.gameObject);
        }
    }



    public float speed = 2.0f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {

            moveiterator++;
           
        }


        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) moveiterator--; ;
        anim.SetInteger("walk", moveiterator);

        float translationH = Input.GetAxis("Horizontal") * speed;
        translationH *= Time.deltaTime;
        transform.Translate(translationH, 0, 0);
        if (translationH < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (translationH > 0)
            transform.localScale = new Vector3(1, 1, 1);

    }
   
}