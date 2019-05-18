using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._SCRIPTS
{
    public class BonusManager : MonoBehaviour
    {
        public GameObject PrefabGift;
        public bool SkillCooldown;

        void Start()
        {

        }
    

        void Update()
        {
            if (Input.GetButtonDown("Fire2") && !SkillCooldown)
            {
                CreateGift(Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                SetGiftCooldown();
            }
        }

        public void CreateGift(Vector2 vector, Quaternion quaternion)
        {
            Instantiate(PrefabGift, vector, quaternion);
        }

        private void SetGiftCooldown()
        {
            var button = GameObject.Find("GiftButton");
            SkillCooldown = true;
            button.GetComponent<Image>().sprite = button.GetComponent<ButtonSprites>().Sprites[1];
            StartCoroutine(ResetCooldown());
        }

        public IEnumerator ResetCooldown()
        {
            yield return new WaitForSeconds(5);
            SkillCooldown = false;
            var button = GameObject.Find("GiftButton");
            button.GetComponent<Image>().sprite = button.GetComponent<ButtonSprites>().Sprites[0];
            yield return 0;
        }
    }
}
