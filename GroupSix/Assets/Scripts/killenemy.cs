using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killenemy : MonoBehaviour
{
     void onCollisionEnter(Collision col){
        Destroy(transform.parent.gameObject);
    }
}
