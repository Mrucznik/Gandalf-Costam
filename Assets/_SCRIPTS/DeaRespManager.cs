using System.Collections;
using UnityEngine;

namespace Assets._SCRIPTS
{
    public class DeaRespManager : MonoBehaviour {

        private PlayerMove _player;
        public GameObject CurrentCheckpoint;
        public GameObject DeathParticle;
        public GameObject RespawnParticle;
        public float RespawnDelay;
    
        // Use this for initialization
        void Start () {
            _player = FindObjectOfType<PlayerMove>();
        

        }
	
        // Update is called once per frame
        void Update () {

        
        }

        public void RespawnPlayer()
        {
            ScoreManag.CountTime(1);
            StartCoroutine("RespawnPlayerCo");
        

        }
        public  IEnumerator RespawnPlayerCo()
        {
        

            Instantiate(DeathParticle, _player.transform.position, _player.transform.rotation);
            _player.enabled = false;
            _player.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(RespawnDelay);
            _player.enabled = true;
            _player.GetComponent<Renderer>().enabled = true;
            _player.transform.position = CurrentCheckpoint.transform.position;
            Instantiate(RespawnParticle, _player.transform.position, _player.transform.rotation);        
        }
    }
}
