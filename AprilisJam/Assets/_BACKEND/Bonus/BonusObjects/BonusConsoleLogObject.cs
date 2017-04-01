using UnityEngine;

namespace Assets._BACKEND.Bonus.BonusObjects
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
