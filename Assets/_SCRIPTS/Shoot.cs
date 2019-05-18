using UnityEngine;

namespace Assets._SCRIPTS
{
    public class Shoot : MonoBehaviour
    {
        volatile float _cooldown = 0, _fireRate = .5f;
        public Transform FirePoint;
        public GameObject Bullet;
        float _timer = 0;

        float _downTime, _pressTime = 0;

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                _downTime = Time.time;
            }
            if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Joystick1Button5))
            {

                _pressTime = Time.time - _downTime;
                _pressTime *= 2;
                if (_pressTime >= 5) _pressTime = 5;

                FirePoint.Translate(0, _pressTime * 0.12f, 0);
                Bullet.GetComponent<ShootControl>().SetForce(_pressTime);

                Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                FirePoint.Translate(0, -_pressTime * 0.12f, 0);
                _cooldown = _fireRate;

            }

            _cooldown -= Time.deltaTime;
        }

  



    }
}