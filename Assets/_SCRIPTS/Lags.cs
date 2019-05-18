using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Lags : MonoBehaviour {



    void Start()
    {
        Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 5000;
        aTimer.Enabled = true;

    }


    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
       Debug.Log("Hello World!");
    }

}


