using System.Timers;
using UnityEngine;

namespace Assets.Backend.Bonus
{
    public class BonusState
    {
        public BonusState()
        {

        }

        public void Update(int time)
        {
            Debug.Log($"Bonus aktywny, czas do znikni�cia: {time}");
        }

        public void Display(int time)
        {
            Debug.Log($"Bonus wystartowa�, czas do znikni�cia: {time}");
        }

        public void Hide()
        {
            Debug.Log("Bonus sie sko�czy�.");
        }
    }
}