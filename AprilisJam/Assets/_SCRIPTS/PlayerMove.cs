using UnityEngine;
using System.Collections;
using System.Timers;

public class PlayerMove : MonoBehaviour
{
    public int obrot = 0, znak = 1;
  
    // Use this for initialization
    void Start()
    {
        
    }

    void FixedUpdate()
    {

    }

    public float speed = 1.0F;
    void Update()
    {
        float translationH = Input.GetAxis("Horizontal") * 2;
        translationH *= Time.deltaTime;
        if (translationH < 0 && obrot < 1)
        {
            obrot = 1;
            transform.Rotate(0, 180, 0);
            znak = -1;

        }
        else if(translationH > 0 && obrot >= 1)
        {
            obrot = 0;
            transform.Rotate(0, 180, 0);
            znak = 1;
            
        }
        transform.Translate(znak*translationH, 0, 0);

    }
   
}