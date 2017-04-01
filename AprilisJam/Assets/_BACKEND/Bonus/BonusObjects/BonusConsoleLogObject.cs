using UnityEngine;

namespace Assets._BACKEND.Bonus.BonusObjects
{
    class BonusConsoleLogObject : IBonusObject
    {
        public void Display()
        {
            Debug.Log("Wyswietlono obiekt fizyczny bonusu");
        }

        public void Hide()
        {
            Debug.Log("Usunięto obiekt fizyczny bonusu");
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
