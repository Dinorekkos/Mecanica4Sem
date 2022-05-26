using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreTxt;

    private int playerScore;

    public int PlayerScore
    {
        get { return playerScore; }
    }
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdatePoints()
    {
        playerScore = playerScore++;
        scoreTxt.text = PlayerScore.ToString();
    }
}
