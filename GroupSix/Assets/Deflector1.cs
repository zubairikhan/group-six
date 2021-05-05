using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflector1 : MonoBehaviour
{
    private bool willDeflect = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        willDeflect = true;

        if (Input.GetKeyDown(KeyCode.G) && willDeflect == true)
        {
            collision.attachedRigidbody.velocity = collision.attachedRigidbody.velocity * -1;
        }



    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        willDeflect = false;
    }
}
