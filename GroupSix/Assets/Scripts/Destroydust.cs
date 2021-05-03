using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroydust : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("dustpart(Clone)"),1f);
    }

   
}
