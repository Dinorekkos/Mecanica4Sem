using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    public static MyTimer Instance;
    
    private bool timerActive = false;
    private float currentTime;
    public float startSeconds;

    public event Action OnTimerFinished;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTime = startSeconds * 60;

    }

    void FixedUpdate()
    {
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                RestartTimer();
            }
        }
    }
    
    public void StartTimer()
    {
        timerActive = true;
    }

    public void RestartTimer()
    {
        timerActive = false;
        currentTime = startSeconds * 60;
        StartTimer();
        OnTimerFinished?.Invoke();
    }

    public void StopTimer()
    {
        timerActive = false;
    }
    
    
    
    
    
    
}
