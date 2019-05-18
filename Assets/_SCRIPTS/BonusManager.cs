using System.Collections;
using System.Collections.Generic;
using Assets._BACKEND.Bonus;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    public GameObject prefabGift;
    public bool skillCooldown;

    void Start()
    {

    }
    

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !skillCooldown)
        {
            CreateGift(Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            SetGiftCooldown();
        }
    }

    public void CreateGift(Vector2 vector, Quaternion quaternion)
    {
        Instantiate(prefabGift, vector, quaternion);
    }

    private void SetGiftCooldown()
    {
        var button = GameObject.Find("GiftButton");
        skillCooldown = true;
        button.GetComponent<Image>().sprite = button.GetComponent<ButtonSprites>().sprites[1];
        StartCoroutine(resetCooldown());
    }

    public IEnumerator resetCooldown()
    {
        yield return new WaitForSeconds(5);
        skillCooldown = false;
        var button = GameObject.Find("GiftButton");
        button.GetComponent<Image>().sprite = button.GetComponent<ButtonSprites>().sprites[0];
        yield return 0;
    }
}
