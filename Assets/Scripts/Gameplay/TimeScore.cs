using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
public class TimeScore : MonoBehaviour
{
    [SerializeField] private bool timerActive;
    [SerializeField] private int startSeconds;
    public int fastesttime;
    public float currentTime;
    public TextMeshProUGUI crTimeText;
    public string timeString { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;
            
            
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
