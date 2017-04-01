using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeX;
    public float smoothTimeY;

    //Shake
    public float shakeTimer;
    public float shakeAmount;

    public GameObject player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    private void FixedUpdate()
    {
        
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);


    }

    //Shake
    void Update()
    {
        if(shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

            shakeTimer -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire2"))
        {
            CameraShake(0.1f, 1);
        }

    }

    //Shale
    public void CameraShake(float shakePwr, float shakeDur)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }
}
