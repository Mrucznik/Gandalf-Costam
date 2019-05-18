using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets._BACKEND.Bonus;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkill : MonoBehaviour
{
    public KeyCode key;
    public int slotid;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        if (Input.GetKeyDown(key) && playerMove.skillCooldown == false)
        {
            var lol = playerMove.bonusy.FindAll(item => item.GetBehaviourState() == 0);
            if (lol.Count > slotid)
                lol.ElementAt(slotid)?.Activate();

            playerMove.skillCooldown = true;
            StartCoroutine(resetCooldown());


            playerMove.SetButtonsTextures();
        }
    }

    public IEnumerator resetCooldown()
    {
        yield return new WaitForSeconds(5);
        var playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        playerMove.skillCooldown = false;
        playerMove.SetButtonsTextures();
        yield return 0;
    }
}