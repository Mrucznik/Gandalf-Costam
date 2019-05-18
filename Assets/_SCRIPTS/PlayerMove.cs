using System;
using System.Collections.Generic;
using Assets._SCRIPTS.Bonus;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Assets._SCRIPTS
{
    public class PlayerMove : MonoBehaviour
    {
        public List<Sprite> ButtonSprites;
        public List<Sprite> ButtonSpritesUnactive;

        public bool SkillCooldown;

        public DeaRespManager LevelManager;
        public List<Bonus.Bonus> Bonusy = new List<Bonus.Bonus>();
        private const int MaxBonus = 5;
        int _sterowanie = 1;

        private Animator _anim;
        private int _moveiterator = 0;
        public int Znak = 1;
        // Use this for initialization
        void Start()
        {
            _anim = GetComponent<Animator>();
            LevelManager = FindObjectOfType<DeaRespManager>();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Gift")
            {
                var bonus = new Bonus.Bonus(CreateRandomBonus());
                if(Bonusy.Count == MaxBonus)
                    bonus.Activate();
                Bonusy.Add(bonus);
                Destroy(col.gameObject);

                SetButtonsTextures();
            }
        
        }

        public void SetButtonsTextures()
        {
            List<Sprite> sprites;
            if(SkillCooldown)
                sprites = GameObject.Find("Player").GetComponent<PlayerMove>().ButtonSpritesUnactive;
            else
                sprites = GameObject.Find("Player").GetComponent<PlayerMove>().ButtonSprites;

            var activeBonusList = GameObject.Find("Player").GetComponent<PlayerMove>().Bonusy.FindAll(item => item.GetBehaviourState() == 0);

            GameObject buttony = GameObject.Find("ButtonContainer");

            for (int i = 0; i < buttony.transform.childCount; i++)
            {
                var buttonObject = buttony.transform.GetChild(i);

                if (i < activeBonusList.Count) //istnieje bonus
                {
                    var bonusType = activeBonusList[i].Behaviour.Type;
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
                            SetButtonSprite(buttonObject, sprites[3]);
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
                LevelManager.RespawnPlayer();
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
            foreach (var bonus in Bonusy)
            {
                if (bonus.Behaviour.GetBehaviourState() == 0)
                    continue;
                switch (bonus.Behaviour.Type)
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

            Bonusy.RemoveAll(item => item.GetBehaviourState() == 3);
        }

        public void AktywujZachowanie()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Bonusy.Find(item => item.GetBehaviourState() == 0)?.Activate();
            }
        }

        public void OdwrocSter()
        {
            _sterowanie = -_sterowanie;
        }


        public float Speed = 2.0f;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {

                _moveiterator++;
           
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) _moveiterator--; ;
            _anim.SetInteger("walk", _moveiterator);

            float translationH = Input.GetAxis("Horizontal") * Speed * _sterowanie;
            translationH *= Time.deltaTime;
            transform.Translate(translationH, 0, 0);
            if (translationH < 0)
            {
                Znak = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (translationH > 0)
            {
                Znak = -1;
                transform.localScale = new Vector3(1, 1, 1);
            }


            if (transform.position.y <= -3.0f)
            {
                LevelManager.RespawnPlayer();
            }

            AktywujZachowanie();
            Behaviours();
        }
   
    }
}