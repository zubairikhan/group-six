using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updraft : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float upwardVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 force = new Vector2(0f, upwardVelocity);
        //playerRb.velocity = new Vector2(playerRb.velocity.x, upwardVelocity);
        playerRb.AddForce(force);
    }
}
