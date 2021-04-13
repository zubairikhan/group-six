using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveEndPanel : MonoBehaviour
{
    public GameObject panelE;
    void OnTriggerEnter2D(){
        panelE.SetActive(true);

    }
}
