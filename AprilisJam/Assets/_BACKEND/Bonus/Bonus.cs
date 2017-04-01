using System.Timers;
using UnityEngine;

namespace Assets._BACKEND.Bonus
{
    //Klasa odpowiedzialna za bonusy dla gracza 
    public class Bonus
    {
        private const int DEFAULT_LIFETIME = 10000;
        private const int DEFAULT_BEHAVIOURTIME = 10000;
        private const int DEFAULT_BEHAVIOURTIMESTEP = 1000;
        
        private int behaviourtime;
        private Timer behaviourTimer;

        private BonusBehaviour _behaviour;

        public Bonus(BonusBehaviour behaviour, int lifetime = DEFAULT_LIFETIME, int behaviourtime = DEFAULT_BEHAVIOURTIME)
        {
            SetBonusBehaviour(behaviour);
            
            this.behaviourtime = behaviourtime;

            InitializeTimers();
        }

        public void Update()
        {
            _behaviour.Update();
        }

        public void Activate()
        {
            ActivateBehaviour();
        }

        private void ActivateBehaviour()
        {
            _behaviour.ActivateBehaviour(behaviourtime);
            behaviourTimer?.Start();
        }

        private void DeactivateBehaviour()
        {
            _behaviour.DeactivateBehaviour();
            behaviourTimer?.Stop();
        }

        public bool IsBehaviourActivated()
        {
            return _behaviour.IsBehaviourActivated();
        }

        public void SetBonusBehaviour(BonusBehaviour b)
        {
            _behaviour = b;
        }

        public void RestartTimers()
        {
            InitializeTimers();
        }

        private void InitializeTimers()
        {
            if (behaviourtime != -1)
                InitializeTimer(out behaviourTimer, DEFAULT_BEHAVIOURTIMESTEP, BehaviourTimerService);
        }

        private void BehaviourTimerService(object sender, ElapsedEventArgs args)
        {
            behaviourtime -= DEFAULT_BEHAVIOURTIMESTEP;
            if (behaviourtime <= 0)
            {
                DeactivateBehaviour();
            }
            else
            {
                _behaviour.UpdateBehaviourTime(behaviourtime);
            }
        }

        private void InitializeTimer(out Timer timer, int time, ElapsedEventHandler f)
        {
            timer = new Timer(time);
            timer.Elapsed += f;
        }
    }
}