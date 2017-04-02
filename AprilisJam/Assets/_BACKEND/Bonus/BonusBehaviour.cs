namespace Assets._BACKEND.Bonus
{
    public enum BonusBehavioursEnum
    {
        ConsoleLog,
        RotateCamera,
        Invisibility
    }


    public class BonusBehaviour
    {
        public BonusBehaviour(BonusBehavioursEnum type)
        {
            _state = new BonusState(type.ToString());
            _active = 0;
            this.type = type;
        }

        private BonusState _state;
        private string nazwa;
        private int _active;
        public BonusBehavioursEnum type;

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
