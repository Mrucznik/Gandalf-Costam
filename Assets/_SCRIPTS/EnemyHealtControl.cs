using UnityEngine;

namespace Assets._SCRIPTS
{
    public class EnemyHealtControl : MonoBehaviour {

        public float EnemyHealth;

        public GameObject DeathEffenct;

    
        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
            if(EnemyHealth <= 0)
            {
                Instantiate(DeathEffenct, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        public void GiveDmg(float dmGtoGive)
        {
            EnemyHealth -= dmGtoGive;
        }
    }
}
