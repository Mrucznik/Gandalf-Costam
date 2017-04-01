using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Rigidbody2D rb;
    public float force = 100f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 10)
        {
            Destroy(this.gameObject);
            Application.LoadLevel(0);
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * force, 0));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
