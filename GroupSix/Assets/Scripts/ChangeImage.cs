using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField]
    //private GameObject bulb; 
    //private SpriteRenderer bulbColor; 

    private int State; // 0 - Off, 1 - On 
    [SerializeField]

    private Sprite[] switchSprites; 
    private Image switchImage; 

    void Start()
    {
        //bulbColor = bulb.GetComponent<SpriteRenderer>();
        State = 0; // bulb is Off at the beginning 
        switchImage = GetComponent<Button>().image;
        switchImage. sprite = switchSprites[State]; 
        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff); 
    }

    private void TurnOnAndOff()
    {
        State = 1 - State;
        switchImage.sprite = switchSprites[State];
    }
}
