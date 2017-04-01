using System.Timers;

namespace Assets.Backend.Bonus
{
    //Klasa odpowiedzialna za bonusy dla gracza
    public class Bonus
    {
        private Timer lifeTimer;
        private BonusBehaviour behaviour;
        private BonusState bonusState;
        private BonusObject bonusObject;

        protected Bonus(BonusBehaviour behaviour, int lifetime, int activetime)
        {
            this.behaviour = behaviour;
            lifeTimer = new Timer(lifetime);
            lifeTimer.Elapsed += (sender, args) =>
            {
                Destroy();
            };
        }

        public void Create()
        {
            
        }

        public void PickUp()
        {
        }

        public void Destroy()
        {
        }

        public void Activate()
        {
            behaviour.ActivateBehaviour();
        }

        public void Deactivate()
        {
            behaviour.DeactivateBehaviour();
        }
    }
}
