using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDebris : BreakablePlatform
{
    [SerializeField] CameraShake cameraShake;
    BoxCollider2D boxCollider;

    private void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Break();
            StartCoroutine(cameraShake.ShakeCamera());
            Destroy(boxCollider);
        }
    }
}
