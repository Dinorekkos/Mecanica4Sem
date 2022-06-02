using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    public Text scoreTxt;

    private int playerScore;

    public int PlayerScore
    {
        get { return playerScore; }
    }
   
    void Start()
    {
        Instance = this;
    }
    
    public void UpdatePoints()
    {
        int i = 1;
        playerScore = playerScore + i;
        scoreTxt.text = PlayerScore.ToString();
        Debug.Log(playerScore);

    }
}
