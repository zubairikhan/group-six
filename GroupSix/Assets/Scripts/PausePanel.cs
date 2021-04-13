using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject Panel;

    public void pausepanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void playgame()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
