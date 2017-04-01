using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootControl : MonoBehaviour {

    public int damage;
    public float destroyDelay;
    public float speed;
    public PlayerMove rb;
    public GameObject deathParticle;
    public GameObject brokenBullet;
    // Use this for initialization
    void Start () {
        rb = FindObjectOfType<PlayerMove>();
        
        if(rb.znak >  0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
	}
	
	// UpdateTime is called once per frame
	void Update () {
        StartCoroutine("WaitAndDestroy");
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * transform.localScale.x, GetComponent<Rigidbody2D>().velocity.y);

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(brokenBullet, other.transform.position, other.transform.rotation);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealtControl>().giveDMG(damage);
        }
        if (other.tag != "Player")
        {
            Instantiate(brokenBullet, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
        }
    }

    public IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

}
