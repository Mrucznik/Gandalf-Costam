using System.Timers;

namespace Assets._BACKEND.Bonus
{
    //Klasa odpowiedzialna za bonusy dla gracza 
    public class Bonus
    {
        private const int DEFAULT_LIFETIME = 10000;
        private const int DEFAULT_BEHAVIOURTIME = 10000;
        private const int DEFAULT_BEHAVIOURTIMESTEP = 1000;

        private int lifetime;
        private int behaviourtime;

        private Timer lifeTimer;
        private Timer behaviourTimer;

        private BonusBehaviour _behaviour;
        private BonusObject _object;

        public Bonus(BonusBehaviour behaviour, BonusObject @object, int lifetime = DEFAULT_LIFETIME, int behaviourtime = DEFAULT_BEHAVIOURTIME)
        {
            SetBonusBehaviour(behaviour);
            SetBonusObject(@object);

            this.lifetime = lifetime;
            this.behaviourtime = behaviourtime;

            InitializeTimers();
        }

        public Bonus(BonusBehaviour behaviour, int lifetime = DEFAULT_LIFETIME, int behaviourtime = DEFAULT_BEHAVIOURTIME)
        {
            SetBonusBehaviour(behaviour);

            this.lifetime = lifetime;
            this.behaviourtime = behaviourtime;

            InitializeTimers();
        }

        public void Activate()
        {
            ActivateBehaviour();
        }

        public void PickUp()
        {
            DisplayObject();
        }

        private void DisplayObject()
        {
            _object.Display();
            lifeTimer.Start();
        }

        private void DestroyObject()
        {
            _object.Hide();
            lifeTimer.Stop();
        }

        private void ActivateBehaviour()
        {
            _behaviour.ActivateBehaviour(behaviourtime);
            behaviourTimer.Start();
        }

        private void DeactivateBehaviour()
        {
            _behaviour.DeactivateBehaviour();
            behaviourTimer.Stop();
        }

        private void SetBonusBehaviour(BonusBehaviour b)
        {
            _behaviour = b;
        }

        private void SetBonusObject(BonusObject b)
        {
            _object = b;
        }

        private void InitializeTimers()
        {
            InitializeTimer(out lifeTimer, lifetime, LifeTimerService);


            InitializeTimer(out behaviourTimer, DEFAULT_BEHAVIOURTIMESTEP, BehaviourTimerService);
        }

        private void LifeTimerService(object sender, ElapsedEventArgs args)
        {
            DestroyObject();
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