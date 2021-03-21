using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed= 1f;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed;
        var newXPos = transform.position.x + deltaX;
        transform.position = new Vector2(newXPos, transform.position.y);
        //float horizontalVelocity = Input.GetAxis("Horizontal") * walkSpeed;
        //rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }
}
