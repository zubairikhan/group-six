using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRotation : MonoBehaviour
{

    private float rotationY;
    public float rotationSpeed;
    public bool Rotation;



    

    // Update is called once per frame
    void Update()
    {
        if(Rotation == false)
        {
            rotationY += Time.deltaTime * rotationSpeed;

        }

        else {

            rotationY += -Time.deltaTime * rotationSpeed;

        }

        transform.rotation = Quaternion.Euler(0, rotationY, 30);


    }
}
