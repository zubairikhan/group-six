using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenuTrigger : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject finalCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        finalCanvas.SetActive(true);
        Time.timeScale = 0;


    }

    public void Restart()
    {
        
        gameManager.LoadMainMenu();
    }
}
