using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    float cooldown = 0, fireRate = .5f;
    public Transform firePoint;
    public GameObject bullet;
    void Update()
    {

        if (Input.GetAxis("FireButton") > 0 && cooldown <= 0f)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            cooldown = fireRate;
        }

        cooldown -= Time.deltaTime;
    }
    
  
}
