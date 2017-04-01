using System.Collections;
using System.Collections.Generic;
using Assets._BACKEND.Bonus;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public GameObject prefabGift;

    void Start()
    {

    }
    

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            CreateGift(Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }

    public void CreateGift(Vector2 vector, Quaternion quaternion)
    {
        Instantiate(prefabGift, vector, quaternion);
    }
}
