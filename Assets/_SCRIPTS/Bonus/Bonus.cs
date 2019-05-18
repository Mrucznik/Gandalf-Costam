using System.Timers;

namespace Assets._SCRIPTS.Bonus
{
    //Klasa odpowiedzialna za bonusy dla gracza 
    public class Bonus
    {
        private const int DefaultLifetime = 10000;
        private const int DefaultBehaviourTime = 10000;
        private const int DefaultBehaviourTimeStep = 1000;
        
        private int _behaviourTime;
        private Timer _behaviourTimer;

        public BonusBehaviour Behaviour;

        public Bonus(BonusBehaviour behaviour, int behaviourTime = DefaultBehaviourTime)
        {
            SetBonusBehaviour(behaviour);
            
            this._behaviourTime = behaviourTime;

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
            Behaviour.ActivateBehaviour(_behaviourTime);
            _behaviourTimer?.Start();
        }

        private void DeactivateBehaviour()
        {
            Behaviour.DeactivateBehaviour();
            _behaviourTimer?.Stop();
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
            if (_behaviourTime != -1)
                InitializeTimer(out _behaviourTimer, DefaultBehaviourTimeStep, BehaviourTimerService);
        }

        private void BehaviourTimerService(object sender, ElapsedEventArgs args)
        {
            _behaviourTime -= DefaultBehaviourTimeStep;
            if (_behaviourTime <= 0)
            {
                DeactivateBehaviour();
            }
            else
            {
                Behaviour.UpdateBehaviourTime(_behaviourTime);
                if(Behaviour.GetBehaviourState() == 3)
                    _behaviourTimer.Stop();
            }
        }

        private void InitializeTimer(out Timer timer, int time, ElapsedEventHandler f)
        {
            timer = new Timer(time);
            timer.Elapsed += f;
        }
    }
}