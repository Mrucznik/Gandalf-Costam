using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangingBgColor : MonoBehaviour {

    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;

    void Start()
    {
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;

        Camera.main.backgroundColor = Color.Lerp(color1, color2, t);
        if(Camera.main.backgroundColor == color2)
        {
            Color tmp = color2;
            color2 = color1;
            color1 = tmp;
        }
    }
}
