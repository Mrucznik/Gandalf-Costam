using UnityEngine;

namespace Assets._BACKEND.Bonus
{
    public class BonusState
    {
        private string name;
        public BonusState(string name)
        {
            this.name = name;
        }

        public void UpdateTime(int time)
        {
            Debug.Log($"Bonus {name} aktywny, czas do znikniêcia: {time}");
        }

        public void Display(int time)
        {
            Debug.Log($"Bonus {name} wystartowa³, czas do znikniêcia: {time}");
        }

        public void Hide()
        {
            Debug.Log($"Bonus {name} sie skoñczy³.");
        }

        public void Update()
        {

        }
    }
}