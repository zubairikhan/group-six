using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgRock : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] DamageDealer damageDealer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" || collision.gameObject.tag == "Ground")
        {
            Destroy(boxCollider);
            Destroy(damageDealer);
        }
    }
}
