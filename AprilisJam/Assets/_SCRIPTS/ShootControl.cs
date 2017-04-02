using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootControl : MonoBehaviour {

    public float damage, scale;
    public float destroyDelay;
    public float speed;
    public PlayerMove rb;
    public GameObject deathParticle;
    public GameObject brokenBullet;
    public bool isEnemy = false;
    public bool isPlayer = false;
    // Use this for initialization
    void Start () {
        rb = FindObjectOfType<PlayerMove>();
        
        if(rb.znak >  0)
        {
            transform.localScale = new Vector3(-1 * scale, 1 * scale, 1 * scale);

        }
        else
        {
            transform.localScale = new Vector3(1 * scale, 1 * scale, 1 * scale);
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
        if (other.gameObject.tag == "Enemy")
        {
            
            other.gameObject.GetComponent<EnemyHealtControl>().giveDMG(damage);
        }
        if (other.gameObject.tag != "Player")
        {
            Instantiate(brokenBullet, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
        }
    }

    public void setForce(float force)
    {
        speed = 30;
        speed *= 1/(force*2);
        damage = 3;
        damage = Mathf.Pow(damage, force);
        scale = 1;
        scale = force;
        print("Speed "+speed + " dmg " + damage + " scale " + scale);

    }
    public IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

}
