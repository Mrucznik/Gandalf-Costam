using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public DeaRespManager levelManager;
	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<DeaRespManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            levelManager.RespawnPlayer();
        }
    }
}
