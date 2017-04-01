using UnityEngine;

namespace Assets._BACKEND.Bonus.BonusBehaviours
{
    class BonusConsoleLogBehaviour : BonusBehaviour
    {
        public BonusConsoleLogBehaviour()
        {
            _state = new BonusState("Logowanie");
        }

        public override void ActivateBehaviour(int time)
        {
            base.ActivateBehaviour(time);

            Debug.Log("Console log behaviour activated!");
        }

        public override void DeactivateBehaviour()
        {
            base.DeactivateBehaviour();

            Debug.Log("Console log behaviour deactivated!");
        }
    }
}
