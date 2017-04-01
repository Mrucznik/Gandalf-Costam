using UnityEngine;
using System.Collections;
using System.Security;
using System.Timers;

public class PlayerMove : MonoBehaviour
{
    public int obrot = 0, znak = 1;
    private Animator anim;
    private int moveiterator = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

    }

    
    public float speed = 1.0F;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {

            moveiterator++;
           
        }


        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) moveiterator--; ;
        anim.SetInteger("walk", moveiterator);


        float translationH = Input.GetAxis("Horizontal") * 2;  // pobiera sterowanie     
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