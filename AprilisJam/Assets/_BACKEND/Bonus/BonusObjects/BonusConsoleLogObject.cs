using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Backend.Bonus.BonusObjects
{
    class BonusConsoleLogObject : BonusObject
    {
        public override void Display()
        {
            Debug.Log("Wyswietlono obiekt fizyczny bonusu");
        }

        public override void Hide()
        {
            Debug.Log("Usunięto obiekt fizyczny bonusu");
        }
    }
}
