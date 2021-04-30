using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    Player obj; 
    Text score;
    private int scoreValue = 0;



    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Cells x" + scoreValue;
    }

    public void IncrementCellCount()
    {
        scoreValue++;
    }

    public void DecrementCellCount()
    {
        scoreValue--;
    }

    public int GetCellCount()
    {
        return scoreValue;
    }

}
