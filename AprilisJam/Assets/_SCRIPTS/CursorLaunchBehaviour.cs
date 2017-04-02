using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorLaunchBehaviour : MonoBehaviour {

    GameObject player;
    Rigidbody2D rbPlayer;
    public bool skillCooldown;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        rbPlayer = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1") && !skillCooldown)
        {
            
            rbPlayer.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position).normalized * 1000);
            SetGiftCooldown();
        }
    }

    private void SetGiftCooldown()
    {
        var button = GameObject.Find("MagnetButton");
        skillCooldown = true;
        button.GetComponent<Image>().sprite = button.GetComponent<ButtonSprites>().sprites[1];
        StartCoroutine(resetCooldown());
    }

    public IEnumerator resetCooldown()
    {
        yield return new WaitForSeconds(3);
        skillCooldown = false;
        var button = GameObject.Find("MagnetButton");
        button.GetComponent<Image>().sprite = button.GetComponent<ButtonSprites>().sprites[0];
        yield return 0;
    }
}
