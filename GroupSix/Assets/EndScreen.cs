using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
 public GameObject Endscrn;

 private void OnTriggerEnter(Collider other){
     if (other.gameObject.tag == "Player"){
         Endscrn.gameObject.SetActive(true);
     }
 }
}
