using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets._SCRIPTS
{
    public class ButtonSkill : MonoBehaviour
    {
        public KeyCode Key;
        public int Slotid;


        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            var playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
            if (Input.GetKeyDown(Key) && playerMove.SkillCooldown == false)
            {
                var lol = playerMove.Bonusy.FindAll(item => item.GetBehaviourState() == 0);
                if (lol.Count > Slotid)
                    lol.ElementAt(Slotid)?.Activate();

                playerMove.SkillCooldown = true;
                StartCoroutine(ResetCooldown());


                playerMove.SetButtonsTextures();
            }
        }

        public IEnumerator ResetCooldown()
        {
            yield return new WaitForSeconds(5);
            var playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
            playerMove.SkillCooldown = false;
            playerMove.SetButtonsTextures();
            yield return 0;
        }
    }
}