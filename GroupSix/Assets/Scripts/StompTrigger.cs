using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompTrigger : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Player player;
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
        if (collision.tag == "Breakable")
        {
            var velocity = new Vector2(playerRb.velocity.x, 0);
            playerRb.velocity = velocity;
            player.SetIsStomping(false);
        }
    }
}
