using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTop : MonoBehaviour
{


    public GameObject lootBattery;
    BatteryRotation obj;
    Player playerobj = new Player();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KillEnemy();
            Instantiate(lootBattery, transform.parent.gameObject.transform.position, Quaternion.identity);
        }
    }



    

    private void KillEnemy()
    {
        FindObjectOfType<audiomanager>().Play("enemy kill");
        Destroy(transform.parent.gameObject);
    }
}
