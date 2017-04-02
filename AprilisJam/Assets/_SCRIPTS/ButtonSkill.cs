using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets._BACKEND.Bonus;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkill : MonoBehaviour
{
    public KeyCode key;
    public int slotid;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(key))
	    {
	        var lol = GameObject.Find("Player").GetComponent<PlayerMove>().bonusy.FindAll(item => item.GetBehaviourState() == 0);
            if(lol.Count > slotid)
                lol.ElementAt(slotid)?.Activate();
        }
	}
}
