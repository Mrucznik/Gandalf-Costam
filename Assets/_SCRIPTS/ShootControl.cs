using System.Collections;
using UnityEngine;

namespace Assets._SCRIPTS
{
    public class ShootControl : MonoBehaviour {

        public float Damage;
        public float DestroyDelay;
        public float Speed, Scale;
        public PlayerMove Rb;
        public GameObject DeathParticle;
        public GameObject BrokenBullet;
        public bool IsEnemy = false;
        public bool IsPlayer = false;
        // Use this for initialization
        void Start () {
            Rb = FindObjectOfType<PlayerMove>();
        
            if(Rb.Znak >  0)
            {
                transform.localScale = new Vector3(-1 * Scale, 1 * Scale, 1 * Scale);
            }
            else
            {
                transform.localScale = new Vector3(1 * Scale, 1 * Scale, 1 * Scale);
            }
        }
	
        // UpdateTime is called once per frame
        void Update () {
            StartCoroutine("WaitAndDestroy");
            GetComponent<Rigidbody2D>().velocity = new Vector2(Speed * transform.localScale.x, GetComponent<Rigidbody2D>().velocity.y);
        }


        void OnCollisionEnter2D(Collision2D other)
        {
            Instantiate(BrokenBullet, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.tag == "Enemy")
            {
            
                other.gameObject.GetComponent<EnemyHealtControl>().GiveDmg(Damage);
            }
            if (other.gameObject.tag != "Player")
            {
                Instantiate(BrokenBullet, other.transform.position, other.transform.rotation);
                Destroy(gameObject);
            }
        }

        public void SetForce(float force)
        {
            Speed = 30;
            Speed *= 1 / (force * 2);
            Damage = 3;
            Damage = Mathf.Pow(Damage, force);
            Scale = 1;
            Scale = force;
            print("Speed " + Speed + " dmg " + Damage + " scale " + Scale);

        }



        public IEnumerator WaitAndDestroy()
        {
            yield return new WaitForSeconds(DestroyDelay);
            Destroy(gameObject);
        }

    }
}
