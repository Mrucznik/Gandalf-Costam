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

        private int lifetime;
        private int behaviourtime;

        private Timer lifeTimer;
        private Timer behaviourTimer;

        private BonusBehaviour _behaviour;
        private IBonusObject _object;

        public Bonus(BonusBehaviour behaviour, IBonusObject @object, int lifetime = DEFAULT_LIFETIME, int behaviourtime = DEFAULT_BEHAVIOURTIME)
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

        public void Update()
        {
            _behaviour.Update();
            _object?.Update();
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
            _object?.Display();
            lifeTimer?.Start();
        }

        private void DestroyObject()
        {
            _object?.Hide();
            lifeTimer?.Stop();
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

        public void SetBonusObject(IBonusObject b)
        {
            _object = b;
        }

        public void RestartTimers()
        {
            InitializeTimers();
        }

        private void InitializeTimers()
        {
            if(lifetime != -1)
                InitializeTimer(out lifeTimer, lifetime, LifeTimerService);

            if(behaviourtime != -1)
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