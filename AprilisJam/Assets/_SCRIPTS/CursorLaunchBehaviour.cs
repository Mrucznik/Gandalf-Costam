using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLaunchBehaviour : MonoBehaviour {

    GameObject player;
    Rigidbody2D rbPlayer;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        rbPlayer = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            
            rbPlayer.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position) * 50);
        }
    }
}
