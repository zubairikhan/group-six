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
            Debug.Log("Collided with enemy: " + collisionsWithEnemy);
            if (collisionsWithEnemy > 1)
            {

                Enemy2move enem = collision.gameObject.GetComponent<Enemy2move>();
                if (enem != null) { 
                    enem.KillEnemy();
                }
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
