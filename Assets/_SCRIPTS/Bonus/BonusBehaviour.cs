namespace Assets._SCRIPTS.Bonus
{
    public enum BonusBehavioursEnum
    {
        ConsoleLog,
        RotateCamera,
        Invisibility,
        Flip
    }


    public class BonusBehaviour
    {
        public BonusBehaviour(BonusBehavioursEnum type)
        {
            _state = new BonusState(type.ToString());
            _active = 0;
            this.Type = type;
        }

        private readonly BonusState _state;
        private string _nazwa;
        private int _active;
        public BonusBehavioursEnum Type;

        public void UpdateBehaviourTime(int time)
        {
            _state?.UpdateTime(time);
        }

        public virtual void ActivateBehaviour(int time)
        {
            _state?.Display(time);
            _active = 1;
        }

        public void PassiveMode()
        {
            _active = 2;
        }

        public virtual void DeactivateBehaviour()
        {
            _state?.Hide();
            _active = 3;
        }

        public virtual int GetBehaviourState()
        {
            return _active;
        }

        public virtual void Update()
        {
            if(_active == 1)
                _state?.Update();
        }
    }
}
