using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField]
     

    private int State; // 0 - Off, 1 - On 
    [SerializeField]

    private Sprite[] switchSprites; 
    private Image switchImage; 
    private bool muted = false;

    void Start()
    {
        if (PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else 
        {
            Load();
        }
        
        State = 0; // sound is Off at the beginning 
        switchImage = GetComponent<Button>().image;
        switchImage. sprite = switchSprites[State]; 
        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff); 
        AudioListener.pause = muted;
    }

    private void TurnOnAndOff()
    {
        if(muted == false){
            muted = true;
            AudioListener.pause = true;
        }
        else{
            muted = false;
            AudioListener.pause = false;
        }

        State = 1 - State;
        switchImage.sprite = switchSprites[State];
        Save();
    }
    private void Load(){
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save(){
        PlayerPrefs.SetInt("muted",muted? 1:0);
    }
}
