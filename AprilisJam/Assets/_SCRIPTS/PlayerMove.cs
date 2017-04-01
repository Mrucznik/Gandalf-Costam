using UnityEngine;
using System.Collections;
using System.Timers;

public class PlayerMove : MonoBehaviour
{
  
    // Use this for initialization
    void Start()
    {
        
    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Gift")
        {
            Destroy(col.gameObject);
        }
    }

    public float speed = 2.0f;
    void Update()
    {

        float translationH = Input.GetAxis("Horizontal") * speed;
        translationH *= Time.deltaTime;
        transform.Translate(translationH, 0, 0);
        if (translationH < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (translationH > 0)
            transform.localScale = new Vector3(1, 1, 1);

    }
   
}