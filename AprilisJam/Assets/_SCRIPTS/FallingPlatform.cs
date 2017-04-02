using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class FallingPlatform : MonoBehaviour {

    private Rigidbody2D rb;
    public float fallDelay;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    public IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        yield return 0;

    }

    void Update()
    {

    }
}
