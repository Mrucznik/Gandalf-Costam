using UnityEngine;
using System.Collections;
using System.Timers;

public class PlayerMove : MonoBehaviour
{

    int jump2 = 0, floor = 0;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

    }

    public float speed = 10.0F;
    void Update()
    {

        float translationH = Input.GetAxis("Horizontal") * speed;

        translationH *= Time.deltaTime;
        transform.Translate(translationH, 0, 0);




    }

}