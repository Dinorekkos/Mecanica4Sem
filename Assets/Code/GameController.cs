using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    private bool _gameStarted = false;

    public bool GameStarted
    {
        get { return _gameStarted; }
        set { _gameStarted = value; }
    }

    public event Action OnstartGame;
    public void StartGame()
    {
        GameStarted = true;
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
