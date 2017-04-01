using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootControl : MonoBehaviour {

    public float lifeTime = 10f;
    public float speed;
    public PlayerMove rb;
    // Use this for initialization
    void Start () {
        rb = FindObjectOfType<PlayerMove>();
	}
	
	// UpdateTime is called once per frame
	void Update () {
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        if(lifeTime <=0)
        {
            die();
        }
        lifeTime -= Time.deltaTime;
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            die();
            Destroy(other.gameObject);
        }
    }
     
    void die()
    {
        Destroy(this.gameObject);
    }

}
