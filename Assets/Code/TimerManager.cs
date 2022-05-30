using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private bool timerActive = false;
    private float currentTime;
    public int startMinutes;
    public Text txtTimer;
    public Image imageUI;
    public Sprite[] countDown;
    void Start()
    {
        StartCoroutine(StartCountDown());
        currentTime = startMinutes * 60;
    }

    void Update()
    {
        txtTimer.text = currentTime.ToString();
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


    private void StartTimer()
    {
        timerActive = true;
    }

    private void StopTimer()
    {
        timerActive = false;
    }
   
    
    
}
