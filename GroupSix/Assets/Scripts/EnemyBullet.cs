using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField] private float lifeTime;
    private int collisionsWithEnemy;

    //public GameObject diePEFFECt;


    void Start()
    {
        collisionsWithEnemy = 0;
        //StartCoroutine(CountDownTimer());
        Destroy(gameObject, lifeTime);
    }

    /*void OnCollisionEnter2D(Collision2D col)
    {
        Die();
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Die();
        }
        if (collision.tag == "Enemy")
        {
            collisionsWithEnemy++;
            if (collisionsWithEnemy > 1)
            {
                collision.gameObject.GetComponent<Enemy2move>().KillEnemy();
                Die();
            }
        }
        
    }


    /*IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }*/

    void Die()
    {
        Destroy(gameObject);
    }
}
