using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Timers;
using Assets._BACKEND.Bonus;
using Random = System.Random;

public class PlayerMove : MonoBehaviour
{
    private List<Bonus> bonusy = new List<Bonus>();

    private Animator anim;
    private int moveiterator = 0;
    public int znak = 1;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Gift")
        {
            var bonus = new Bonus(CreateRandomBonus());
            bonus.Activate();
            bonusy.Add(bonus);
            Destroy(col.gameObject);
        }
    }



    private BonusBehaviour CreateRandomBonus()
    {
        Random rand = new Random();
        int random = rand.Next(0, 100);

        if(random < 10)
            return new BonusBehaviour(BonusBehavioursEnum.ConsoleLog);
        if(random < 20)
            return new BonusBehaviour(BonusBehavioursEnum.Invisibility);
        return new BonusBehaviour(BonusBehavioursEnum.RotateCamera);
    }

    private void Behaviours()
    {
        foreach (var bonus in bonusy)
        {
            if (bonus.Behaviour.GetBehaviourState() == 0)
                continue;
            switch (bonus.Behaviour.type)
            {
                case BonusBehavioursEnum.ConsoleLog:
                    if (bonus.Behaviour.GetBehaviourState() == 1)
                    {
                        Debug.Log("Console log behaviour activated!");
                    }
                    else
                    {
                        Debug.Log("Console log behaviour deactivated!");
                    }
                    break;
                case BonusBehavioursEnum.RotateCamera:
                    if (bonus.Behaviour.GetBehaviourState() == 1)
                    {
                        Camera.main.transform.Rotate(0, 0, 90 * Time.deltaTime);
                    }
                    else
                    {
                        
                    }
                    break;
                case BonusBehavioursEnum.Invisibility:
                    if (bonus.Behaviour.GetBehaviourState() == 1)
                    {
                        this.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    else 
                    {
                        this.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    break;
            }
        }
    }


    public float speed = 2.0f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {

            moveiterator++;
           
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) moveiterator--; ;
        anim.SetInteger("walk", moveiterator);

        float translationH = Input.GetAxis("Horizontal") * speed;
        translationH *= Time.deltaTime;
        transform.Translate(translationH, 0, 0);
        if (translationH < 0)
        {
            znak = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (translationH > 0)
        {
            znak = -1;
            transform.localScale = new Vector3(1, 1, 1);
        }


        Behaviours();
    }
   
}