using UnityEngine;

namespace Assets._SCRIPTS
{
    public class Invisibility : MonoBehaviour {

        GameObject _player;
        bool _visible = true;
        // Use this for initialization
        void Start () {
            _player = GameObject.Find("Player");
        }
	
        // Update is called once per frame
        void Update () {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _visible = !_visible;
            }
            _player.GetComponent<SpriteRenderer>().enabled = _visible;
        }
    }
}
