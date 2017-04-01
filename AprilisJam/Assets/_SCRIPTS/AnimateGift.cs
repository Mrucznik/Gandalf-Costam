using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateGift : MonoBehaviour {

    private int timer = 0;
    private int timer2 = 0;
    private bool os = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Animate();
	}

    private void Animate()
    {
        float value = 1 * (os ? -1 : 1) * Time.deltaTime;
        this.transform.localScale += new Vector3(value, 0, 0);
        this.transform.localScale += new Vector3(0, -value, 0);

        if (timer2 == 0)
        {
            os = !os;
        }
        else
        {
            timer2 = (timer2 + 1) % 1000;
        }
    }
}
