using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    
    public static GameController Instance;

    public GameObject canvasFinishedGame;
    private bool _gameStarted = false;
    
    public gameStates GameStates;

    public enum gameStates
    {
        None,
        GameStarted,
        GameFinished,
    }
    
    public void StartGame()
    {
        GameStates = gameStates.GameStarted;
        TimerManager.Instance.StartTimer();
        MyTimer.Instance.StartTimer();
        
        HandleGameState();
        
    }

    public void EndGame()
    {
        GameStates = gameStates.GameFinished;
        MyTimer.Instance.StopTimer();
        Debug.Log("GameFinished");
        
        HandleGameState();

    }

    private void HandleGameState()
    {
        switch (GameStates)
        {
            case gameStates.None:
                canvasFinishedGame.SetActive(false);

                break;
            case gameStates.GameStarted:
                canvasFinishedGame.SetActive(false);
                break;
            case gameStates.GameFinished :
                canvasFinishedGame.SetActive(true);

                break;
                
        }
    }
    
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TimerManager.Instance.OnFinishTimer += EndGame;
        GameStates = gameStates.None;
    }





}
