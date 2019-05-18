using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._SCRIPTS
{
    public class CursorLaunchBehaviour : MonoBehaviour {

        GameObject _player;
        Rigidbody2D _rbPlayer;
        public bool SkillCooldown;

        // Use this for initialization
        void Start () {
            _player = GameObject.Find("Player");
            _rbPlayer = _player.GetComponent<Rigidbody2D>();
        }
	
        // Update is called once per frame
        void Update () {
            if(Input.GetButtonDown("Fire1") && !SkillCooldown)
            {
            
                _rbPlayer.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - _player.transform.position).normalized * 1000);
                SetMagnetCooldown();
            }
        }

        private void SetMagnetCooldown()
        {
            var button = GameObject.Find("MagnetButton");
            SkillCooldown = true;
            button.GetComponent<Image>().sprite = button.GetComponent<ButtonSprites>().Sprites[1];
            StartCoroutine(ResetCooldown());
        }

        public IEnumerator ResetCooldown()
        {
            yield return new WaitForSeconds(3);
            SkillCooldown = false;
            var button = GameObject.Find("MagnetButton");
            button.GetComponent<Image>().sprite = button.GetComponent<ButtonSprites>().Sprites[0];
            yield return 0;
        }
    }
}
