using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    private bool _gameStarted = false;
    private bool _gameFinished = false;

    public bool GameFinished
    {
        get { return _gameFinished; }
        set { _gameFinished = value; }
    }
    public bool GameStarted
    {
        get { return _gameStarted; }
        set { _gameStarted = value; }
    }

    public event Action OnstartGame;
    public void StartGame()
    {
        GameStarted = true;
        TimerManager.Instance.StartTimer();
        MyTimer.Instance.StartTimer();
        
    }

    public void EndGame()
    {
        GameFinished = true;
        GameStarted = false;
        TimerManager.Instance.StopTimer();
        
    }
    
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleGameCondition()
    {
        
    }

    
    
    
}
