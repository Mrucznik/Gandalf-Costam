using System.Timers;
using UnityEngine;

namespace Assets.Backend.Bonus
{
    public class BonusState
    {
        private Bonus bonus;
        private bool activated;
        private int timeLeft;
        private Timer timer;

        BonusState(Bonus bonus, int timeLeft)
        {
            this.bonus = bonus;
            activated = false;
            this.timeLeft = timeLeft;
            timer = new Timer(1000);
            timer.Elapsed += (source, e) =>
            {
                NextTimerStep();
            };
        }

        public bool Activated
        {
            get { return activated; }
            set { activated = value; }
        }

        public void Activate()
        {
            activated = true;
            timer.Start();
        }

        public void Deactivate()
        {
            timer.Stop();
            bonus.Deactivate();
            activated = false;
        }

        private void NextTimerStep()
        {
            timeLeft--;
            if (timeLeft <= 0)
            {
                TimerEnd();
            }
        }

        private void TimerEnd()
        {
            Deactivate();
        }

        //Graficzne
        public void Display()
        {
            Debug.Log($"Bonus aktywny, czas do znikniêcia: {timeLeft}");
        }

        public void Hide()
        {
            Debug.Log("Bonus sie skoñczy³.");
        }
    }
}