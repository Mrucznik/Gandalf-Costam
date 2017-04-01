namespace Assets.Backend.Bonus
{
    public abstract class BonusBehaviour
    {
        private bool _active;

        public virtual void ActivateBehaviour()
        {
            _active = true;
        }

        public virtual void DeactivateBehaviour()
        {
            _active = false;
        }

        public virtual bool IsBehaviourActivated()
        {
            return _active;
        }
    }
}
