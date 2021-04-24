using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTop : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(transform.parent.gameObject);
    }
}
