using System.Timers;
using UnityEngine;

namespace Assets.Backend.Bonus
{
    public abstract class BonusObject
    {
        public BonusObject()
        {
            
        }

        public abstract void Display();
        public abstract void Hide();
    }
}