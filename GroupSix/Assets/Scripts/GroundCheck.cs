using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
   [SerializeField] GameObject dustcloud;

   void OnTriggerEnter2D(Collider2D col){
       if (col.gameObject.tag.Equals("Ground"))
        Instantiate(dustcloud,transform.position,dustcloud.transform.rotation);
   }

   
}
