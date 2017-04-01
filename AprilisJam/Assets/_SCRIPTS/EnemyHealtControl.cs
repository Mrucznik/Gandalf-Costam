﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtControl : MonoBehaviour {

    public int enemyHealth;

    public GameObject deathEffenct;

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(enemyHealth <= 0)
        {
            Instantiate(deathEffenct, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}

    public void giveDMG(int DMGtoGive)
    {
        enemyHealth -= DMGtoGive;
    }
}