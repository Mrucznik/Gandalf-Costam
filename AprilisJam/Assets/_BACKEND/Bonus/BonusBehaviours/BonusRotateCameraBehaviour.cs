using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._BACKEND.Bonus.BonusBehaviours
{
    class BonusRotateCameraBehaviour : BonusBehaviour
    {
        public BonusRotateCameraBehaviour()
        {
            _state = new BonusState("'Kryncenie Ekranem'");
        }

        public override void ActivateBehaviour(int time)
        {
            base.ActivateBehaviour(time);
        }

        public override void DeactivateBehaviour()
        {
            base.DeactivateBehaviour();
        }

        public override void Update()
        {
            base.Update();

            if (_active)
            {
                Behaviour();
            }
        }

        private void Behaviour()
        {
            Camera.main.transform.Rotate(0, 0, 90 * Time.deltaTime);
        }
    }
}
