using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    float cooldown = 0, fireRate = .1f;
    public Transform firePoint;
    public GameObject bullet;

    float downTime, pressTime = 0;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            downTime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.E) && cooldown <= 0f)
        {

            pressTime = Time.time - downTime;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            cooldown = fireRate;

        }
        cooldown -= Time.deltaTime;
    }
    


}
