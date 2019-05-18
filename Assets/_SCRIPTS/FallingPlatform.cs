using System.Collections;
using UnityEngine;

namespace Assets._SCRIPTS
{
    public class FallingPlatform : MonoBehaviour {

        private Rigidbody2D _rb;
        public float FallDelay;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Fall());
            }
        }

        public IEnumerator Fall()
        {
        
            yield return new WaitForSeconds(FallDelay);
            _rb.isKinematic = false;
            GetComponent<Collider2D>().isTrigger = true;
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).tag == "Spikes")
                {
                    this.transform.GetChild(i).transform.GetChild(0).GetComponent<Collider2D>().isTrigger = true;
                }
            }
            yield return 0;

        }

        void Update()
        {

        }
    }
}
