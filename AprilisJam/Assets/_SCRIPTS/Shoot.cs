using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
    
  
}
