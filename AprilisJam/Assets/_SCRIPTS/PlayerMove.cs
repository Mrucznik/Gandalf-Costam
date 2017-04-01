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

    public float speed = 2.0f;
    void Update()
    {
        float translationH = Input.GetAxis("Horizontal") * speed;
        translationH *= Time.deltaTime;

        transform.Translate(translationH, 0, 0);
        if (translationH < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

    }
   
}