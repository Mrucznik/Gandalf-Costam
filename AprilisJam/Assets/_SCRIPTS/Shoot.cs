using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    volatile float cooldown = 0, fireRate = .5f;
    public Transform firePoint;
    public GameObject bullet;
    float Timer = 0;

    float downTime, pressTime = 0;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
             downTime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Joystick1Button5))
        {

            pressTime = Time.time - downTime;
            pressTime *= 2;
            if (pressTime >= 5) pressTime = 5;

            firePoint.Translate(0, pressTime * 0.12f, 0);
            bullet.GetComponent<ShootControl>().setForce(pressTime);

            Instantiate(bullet, firePoint.position, firePoint.rotation);
            firePoint.Translate(0, -pressTime * 0.12f, 0);
            cooldown = fireRate;

        }

        cooldown -= Time.deltaTime;
    }

  



}