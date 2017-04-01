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
            Debug.Log($"Bonus aktywny, czas do znikniêcia: {time}");
        }

        public void Display(int time)
        {
            Debug.Log($"Bonus wystartowa³, czas do znikniêcia: {time}");
        }

        public void Hide()
        {
            Debug.Log("Bonus sie skoñczy³.");
        }
    }
}