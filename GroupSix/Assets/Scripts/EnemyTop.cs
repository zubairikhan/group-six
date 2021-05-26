using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTop : MonoBehaviour
{
    [SerializeField] GameObject lootBattery;
    
    [SerializeField] enemy1move enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.KillEnemy();
            if (lootBattery != null) { 
                Instantiate(lootBattery, transform.parent.gameObject.transform.position, Quaternion.identity);
            }
        }

    }

    
}
