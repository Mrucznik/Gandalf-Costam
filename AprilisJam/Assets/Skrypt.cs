using System.Collections;
using System.Collections.Generic;
using Assets.Backend.Bonus;
using Assets.Backend.Bonus.BonusBehaviours;
using Assets.Backend.Bonus.BonusObjects;
using UnityEngine;

public class Skrypt : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Sztart");

        Bonus bonus = new Bonus(new BonusConsoleLogBehaviour(), new BonusConsoleLogObject(), 5000, 10000);
        bonus.PickUp();
        bonus.Activate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
