using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
public class TimeScore : MonoBehaviour
{
    private bool timerActive;
    [SerializeField] private int startSeconds;
    public string score;
    public int fastesttime;
    float currentTime;
    public TextMeshProUGUI crTimeText;
    public TextMeshProUGUI bsTimeText;
    public string timeString { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startSeconds;
        TimeSpan bestTime = TimeSpan.FromSeconds(0);
        bsTimeText.text = $"Total: {bestTime.Minutes:00}:{bestTime.Seconds:00}";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;
            
            if (currentTime<=0)
            {
                //do something here
                StopTimer();
            }
        }
        //fastest time
        fastesttime =  startSeconds - Mathf.RoundToInt(currentTime);
        

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeString = $"{time.Minutes:00}:{time.Seconds:00}";
        crTimeText.text = timeString;
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
