using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Backend.Bonus.BonusBehaviours
{
    class BonusConsoleLogBehaviour : BonusBehaviour
    {
        public BonusConsoleLogBehaviour()
        {
            _state = new BonusState();
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
