using UnityEngine;
using System.Collections;
using System.Timers;

public class RotateCamera : MonoBehaviour
{
    float rotTimer = 0f;
    public float timer = 5f;
    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            rotTimer += timer;
        }
        if(rotTimer > 0)
        {
            Debug.Log(rotTimer);
            Camera.main.transform.Rotate(0, 0, 90 * Time.deltaTime);
        }
        else
        {
            Camera.main.transform.Rotate(0, 0, -Camera.main.transform.rotation.z * Time.deltaTime);
        }
        
        rotTimer -= .1f * Time.deltaTime;

    }

}