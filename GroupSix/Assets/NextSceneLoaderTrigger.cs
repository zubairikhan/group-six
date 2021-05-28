using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneLoaderTrigger : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            gameManager.LoadNextScene();
        }
    }

}
