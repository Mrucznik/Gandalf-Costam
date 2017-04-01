using UnityEngine;
using System.Collections;
using System.Timers;
using Assets._BACKEND.Bonus;
using Assets._BACKEND.Bonus.BonusBehaviours;

public class RotateCamera : MonoBehaviour
{
    private Bonus bonus;

    void Start()
    {
        bonus = new Bonus(new BonusRotateCameraBehaviour());
    }

    void FixedUpdate()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            if(!bonus.IsBehaviourActivated())
                bonus.Activate();
        }
        bonus.Update();
    }


}
