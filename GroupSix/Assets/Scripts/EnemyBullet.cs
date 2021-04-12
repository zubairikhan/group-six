using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float dieTime, damage;
    //public GameObject diePEFFECt;


    void Start()
    {
        //StartCoroutine(CountDownTimer());
        Destroy(gameObject, dieTime);
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
