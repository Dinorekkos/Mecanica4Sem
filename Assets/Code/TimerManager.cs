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
    public Image imageGO;

    public GameObject GameCanvas;
    public GameObject panelCountDown;
    public Sprite[] countDown;

    public event Action OnFinishTimer;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }


    public void ButtonStartTimer()
    {
        GameCanvas.SetActive(true);
        panelCountDown.SetActive(true);
        imageGO.gameObject.SetActive(false);
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
                StopTimer();
            }
        }

        
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        txtTimer.text = "0"+ timeSpan.Minutes + ":" + timeSpan.Seconds;
    }
    
    IEnumerator StartCountDown()
    {
        imageUI.sprite = countDown[2];
        yield return new WaitForSeconds(1);
        imageUI.sprite = countDown[1];
        yield return new WaitForSeconds(1);
        imageUI.sprite = countDown[0];
        yield return new WaitForSeconds(1);
        imageGO.gameObject.SetActive(true);       
        imageUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.8f);



        imageUI.sprite = null;
        panelCountDown.SetActive(false);
        imageGO.gameObject.SetActive(false);
        GameController.Instance.StartGame();
    }


    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
        OnFinishTimer?.Invoke();
    }
   
    
    
}
