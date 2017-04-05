using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Timers;
using Assets._BACKEND.Bonus;
using UnityEngine.UI;
using Random = System.Random;

public class PlayerMove : MonoBehaviour
{
    public List<Sprite> buttonSprites;
    public List<Sprite> buttonSpritesUnactive;

    public bool skillCooldown;

    public DeaRespManager levelManager;
    public List<Bonus> bonusy = new List<Bonus>();
    private const int maxBonus = 5;
    int sterowanie = 1;

    private Animator anim;
    private int moveiterator = 0;
    public int znak = 1;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        levelManager = FindObjectOfType<DeaRespManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Gift")
        {
            var bonus = new Bonus(CreateRandomBonus());
            if(bonusy.Count == maxBonus)
                bonus.Activate();
            bonusy.Add(bonus);
            Destroy(col.gameObject);

            SetButtonsTextures();
        }
        
    }

    public void SetButtonsTextures()
    {
        List<Sprite> sprites;
        if(skillCooldown)
            sprites = GameObject.Find("Player").GetComponent<PlayerMove>().buttonSpritesUnactive;
        else
            sprites = GameObject.Find("Player").GetComponent<PlayerMove>().buttonSprites;

        var activeBonusList = GameObject.Find("Player").GetComponent<PlayerMove>().bonusy.FindAll(item => item.GetBehaviourState() == 0);

        GameObject buttony = GameObject.Find("ButtonContainer");

        for (int i = 0; i < buttony.transform.childCount; i++)
        {
            var buttonObject = buttony.transform.GetChild(i);

            if (i < activeBonusList.Count) //istnieje bonus
            {
                var bonusType = activeBonusList[i].Behaviour.type;
                switch (bonusType)
                {
                    case BonusBehavioursEnum.ConsoleLog:
                        SetButtonSprite(buttonObject, sprites[1]);
                        break;
                    case BonusBehavioursEnum.RotateCamera:
                        SetButtonSprite(buttonObject, sprites[1]);
                        break;
                    case BonusBehavioursEnum.Invisibility:
                        SetButtonSprite(buttonObject, sprites[2]);
                        break;
                    case BonusBehavioursEnum.Kill:
                        SetButtonSprite(buttonObject, sprites[0]);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else //pusty
            {
                SetButtonSprite(buttonObject, sprites[0]);
            }
        }
    }

    private void SetButtonSprite(Transform buttonObject, Sprite sprite)
    {
        buttonObject.GetComponent<Image>().sprite = sprite;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Spikes")
        {
            levelManager.RespawnPlayer();
        }
    }


    private BonusBehaviour CreateRandomBonus()
    {
        Random rand = new Random();
        int random = rand.Next(0, 100);

        if (random < 20)
            return new BonusBehaviour(BonusBehavioursEnum.Invisibility);
        if (random < 22)
            return new BonusBehaviour(BonusBehavioursEnum.Kill);
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
                        bonus.Behaviour.PassiveMode();
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
                        Debug.Log("Console log behaviour activated!");
                        Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, new Quaternion(0, 0, Camera.main.transform.rotation.z + 0.1f, 0), 1f * Time.deltaTime);
                    }
                    else
                    {
                        
                        Debug.Log("Console log behaviour deactivated!");
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
                case BonusBehavioursEnum.Kill:
                    if (bonus.Behaviour.GetBehaviourState() == 1)
                    { 
                        DeaRespManager levelManager;
                        levelManager = FindObjectOfType<DeaRespManager>();
                        levelManager.RespawnPlayer();
                        bonus.Behaviour.DeactivateBehaviour();
                    }
                    break;
                default:
                    Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, new Quaternion(0, 0, transform.rotation.z + 0.1f, 0), 1f * Time.deltaTime);
                    break;
            }
        }

        bonusy.RemoveAll(item => item.GetBehaviourState() == 3);
    }

    public void aktywujZachowanie()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            bonusy.Find(item => item.GetBehaviourState() == 0)?.Activate();
        }
    }

    public void odwrocSter()
    {
        sterowanie = -sterowanie;
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

        float translationH = Input.GetAxis("Horizontal") * speed * sterowanie;
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




        aktywujZachowanie();
        Behaviours();
    }
   
}