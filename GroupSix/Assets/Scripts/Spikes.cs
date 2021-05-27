using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spikes : MonoBehaviour
{
    [SerializeField] Player player;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Die();
        }
    }




    public void Die()
    {
        Respawn();
        


    }

    private void Respawn()
    {
        player.transform.position = player.checkPoint;
        player.playerHealth.InitializeHealthStatus();
    }


}
