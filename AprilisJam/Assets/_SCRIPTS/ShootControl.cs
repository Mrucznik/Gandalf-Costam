using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour {

  
    public float speed;
    public PlayerMove rb;
    // Use this for initialization
    void Start () {
        rb = FindObjectOfType<PlayerMove>();
        speed = rb.znak * speed;
	}
	
	// UpdateTime is called once per frame
	void Update () {
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
     
}
