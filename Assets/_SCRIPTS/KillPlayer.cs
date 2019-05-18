using UnityEngine;

namespace Assets._SCRIPTS
{
    public class KillPlayer : MonoBehaviour {

        public DeaRespManager LevelManager;
        // Use this for initialization
        void Start () {
            LevelManager = FindObjectOfType<DeaRespManager>();
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == "Player")
            {
                LevelManager.RespawnPlayer();
            }
        }
    }
}
