using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._BACKEND.Bonus.BonusObjects
{
    public class BonusGiftObject : MonoBehaviour, IBonusObject
    {
        public GameObject giftPrefab;
        GameObject gift;

        public BonusGiftObject()
        {
            
        }

        public void Start()
        {
            gift = Instantiate(giftPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        }

        public void Display()
        {
        }

        public void Hide()
        {
            Destroy(gift);
        }

        public void Update()
        {

        }
    }
}
