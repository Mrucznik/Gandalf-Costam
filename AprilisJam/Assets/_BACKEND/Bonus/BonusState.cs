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
            Debug.Log($"Bonus {name} aktywny, czas do znikni�cia: {time}");
        }

        public void Display(int time)
        {
            Debug.Log($"Bonus {name} wystartowa�, czas do znikni�cia: {time}");
        }

        public void Hide()
        {
            Debug.Log($"Bonus {name} sie sko�czy�.");
        }

        public void Update()
        {

        }
    }
}