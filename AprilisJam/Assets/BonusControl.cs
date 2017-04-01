using System.Collections;
using System.Collections.Generic;
using Assets._BACKEND.Bonus;
using Assets._BACKEND.Bonus.BonusBehaviours;
using Assets._BACKEND.Bonus.BonusObjects;
using UnityEngine;

public class BonusControl : MonoBehaviour
{
    private Bonus bonus;
	// Use this for initialization
	void Start () {
        Debug.Log("Sztart");

        bonus = new Bonus(new BonusConsoleLogBehaviour(), new BonusConsoleLogObject(), 5000, 10000);
        bonus.PickUp();
        bonus.Activate();
	}
	
	// UpdateTime is called once per frame
	void Update () {
	    bonus.Update();	
	}
}
