using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManag : MonoBehaviour {

    public static float time;
    public static float downTime;
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
        time = 0;

        downTime = Time.time;

    }

    void Update()
    {
        if (time < 0)
            time = 0;


        ScoreManag.CountTime(0);

        text.text = "" + time;
    }

    public static void CountTime (int stop)
    {
        if (stop == 0)
        {
            time = Time.time - downTime;
        }
        else
        {
            time = 0;
            downTime = Time.time;
            Time.timeScale = 0;
            
            
        }
    }
    
}
