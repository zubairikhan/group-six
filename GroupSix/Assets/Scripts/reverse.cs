using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverse : MonoBehaviour
{
    private bool willDeflect = true;
    private Rigidbody2D rb = null;

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.G) && willDeflect == true && rb != null)
        {

            rb.velocity = -rb.velocity;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody2D>();
        willDeflect = true;
        
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        willDeflect = false;
        rb = null;
    }
}
