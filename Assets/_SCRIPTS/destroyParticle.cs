using UnityEngine;

namespace Assets._SCRIPTS
{
    public class DestroyParticle : MonoBehaviour {

        private ParticleSystem _thisParticleSystem;
        // Use this for initialization
        void Start () {

            _thisParticleSystem = GetComponent<ParticleSystem>();
        }
	
        // Update is called once per frame
        void Update () {
            if (_thisParticleSystem.isPlaying)
                return;
            Destroy(gameObject);
        }
    }
}
