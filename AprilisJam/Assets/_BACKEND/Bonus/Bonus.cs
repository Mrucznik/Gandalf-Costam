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

        public BonusBehaviour Behaviour;

        public Bonus(BonusBehaviour behaviour, int behaviourtime = DEFAULT_BEHAVIOURTIME)
        {
            SetBonusBehaviour(behaviour);
            
            this.behaviourtime = behaviourtime;

            InitializeTimers();
        }

        public void Update()
        {
            Behaviour.Update();
        }

        public void Activate()
        {
            ActivateBehaviour();
        }

        private void ActivateBehaviour()
        {
            Behaviour.ActivateBehaviour(behaviourtime);
            behaviourTimer.Start();
        }

        private void DeactivateBehaviour()
        {
            Behaviour.DeactivateBehaviour();
            behaviourTimer.Stop();
        }

        public int GetBehaviourState()
        {
            return Behaviour.GetBehaviourState();
        }

        public void SetBonusBehaviour(BonusBehaviour b)
        {
            Behaviour = b;
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
                Behaviour.UpdateBehaviourTime(behaviourtime);
                if(Behaviour.GetBehaviourState() == 3)
                    behaviourTimer.Stop();
            }
        }

        private void InitializeTimer(out Timer timer, int time, ElapsedEventHandler f)
        {
            timer = new Timer(time);
            timer.Elapsed += f;
        }
    }
}