using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverse : MonoBehaviour
{
    private bool willDeflect = false;
    private Rigidbody2D rb = null;
    [SerializeField] Player player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody2D>();
        willDeflect = true;
        player.SetEnemyProjectileRb(rb);
        player.SetWillDeflect(willDeflect);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        willDeflect = false;
        rb = null;
        player.SetEnemyProjectileRb(rb);
        player.SetWillDeflect(willDeflect);
    }
}
