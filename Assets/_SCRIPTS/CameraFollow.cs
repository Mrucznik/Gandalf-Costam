using UnityEngine;

namespace Assets._SCRIPTS
{
    public class CameraFollow : MonoBehaviour {

        private Vector2 _velocity;

        public float SmoothTimeX;
        public float SmoothTimeY;

        //Shake
        public float ShakeTimer;
        public float ShakeAmount;

        public GameObject Player;

        void Start ()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        private void FixedUpdate()
        {
        
            float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref _velocity.x, SmoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref _velocity.y, SmoothTimeY);

            transform.position = new Vector3(posX, posY, transform.position.z);


        }

        //Shake
        void Update()
        {
            if(ShakeTimer >= 0)
            {
                Vector2 shakePos = Random.insideUnitCircle * ShakeAmount;

                transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);

                ShakeTimer -= Time.deltaTime;
            }
            if(Input.GetButtonDown("Fire2"))
            {
                CameraShake(0.1f, 1);
            }

        }

        //Shale
        public void CameraShake(float shakePwr, float shakeDur)
        {
            ShakeAmount = shakePwr;
            ShakeTimer = shakeDur;
        }
    }
}
