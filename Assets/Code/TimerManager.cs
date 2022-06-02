using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;
    
    private bool timerActive = false;
    private float currentTime;
    public int startMinutes;
    public Text txtTimer;
    public Image imageUI;
    public Sprite[] countDown;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(StartCountDown());
        currentTime = startMinutes * 60;
    }

    void FixedUpdate()
    {
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
                currentTime = startMinutes * 60;
            }
        }

        
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        txtTimer.text = timeSpan.Minutes + ":" + timeSpan.Seconds;
    }
    
    IEnumerator StartCountDown()
    {
        imageUI.sprite = countDown[2];
        yield return new WaitForSeconds(1);
        imageUI.sprite = countDown[1];
        yield return new WaitForSeconds(1);
        imageUI.sprite = countDown[0];
        yield return new WaitForSeconds(1);

        imageUI.sprite = null;
        imageUI.gameObject.SetActive(false);
        GameController.Instance.StartGame();
    }


    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
   
    
    
}
