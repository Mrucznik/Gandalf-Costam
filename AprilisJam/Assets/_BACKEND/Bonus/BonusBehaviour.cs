namespace Assets._BACKEND.Bonus
{
    public abstract class BonusBehaviour
    {
        protected BonusState _state;
        protected bool _active;

        public void UpdateBehaviourTime(int time)
        {
            _state?.UpdateTime(time);
        }

        public virtual void ActivateBehaviour(int time)
        {
            _state?.Display(time);
            _active = true;
        }

        public virtual void DeactivateBehaviour()
        {
            _state?.Hide();
            _active = false;
        }

        public virtual bool IsBehaviourActivated()
        {
            return _active;
        }

        public virtual void Update()
        {
            if(_active)
                _state?.Update();
        }
    }
}
