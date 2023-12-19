using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;


[Serializable]
public class MyEvent : UnityEvent<string, GameObject> { }
[RequireComponent(typeof(TimeScore))]
public class LevelManager : MonoBehaviour
{

    // Start is called before the first frame update
    private IExtinguishable[] extinguishables= new IExtinguishable[0];
    private TimeScore timeScore;
    [SerializeField] private GameObject endButton;
    [SerializeField] private Collider startTrigger;
    public MyEvent OnEvent;
    void Start()
    {
        //Debug.Log(CalculateScore());
        timeScore = GetComponent<TimeScore>();
    }
    private void Update()
    {

        if (timeScore.currentTime <= 0)
        {
            EndLevel();
        }
        
    }
    // Update is called once per frame
    public void StartLevel()
    {
        //start timer
        timeScore.StartTimer();
        
    }
    
    //If player gets out
    public void EndLevel()
    {
        //end timer
        //calculate and save score
        //tp back to menu
        if (timeScore.timerActive)
        {
            Debug.Log("Score: "+CalculateScore());
            endButton.SetActive(false);
            timeScore.StopTimer();
            SaveScore();
            LoadLevel(0);
            return;
        }

       
    }

    private const string ScoreKey = "HighScore";

    // Save the player score
    public void SaveScore()
    {
        if (PlayerPrefs.GetFloat(ScoreKey)> CalculateScore())
        {
            return;
        }
        PlayerPrefs.SetFloat(ScoreKey, CalculateScore());
        PlayerPrefs.Save();
    }

    float CalculateScore()
    {
        var extinguishables = FindObjectsOfType<MonoBehaviour>(true).OfType<IExtinguishable>();

        foreach (IExtinguishable e in extinguishables)
        {
            Debug.Log(e.getState());
        }
        int time = timeScore.fastesttime;
        if (time==0)
        {
            time = 1;
        }
        float extinguished = extinguishables.Count(extinguishable => extinguishable.getState());
        float total = extinguishables.Count();
        Debug.Log($"{extinguished/total} {1.0f / (float)time}");
        return (extinguished / total * (1.0f/(float)time))*1000;
    }

    public void LoadLevel(int id)
    {
        StartCoroutine(loadasync(id));

    }
   
    IEnumerator loadasync(int sceneid)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneid);
        while (!loading.isDone)
        {
            float loadvalue = Mathf.Clamp01(loading.progress / 0.9f);
            //Debug.Log("Sudah load " + loadvalue);
            yield return null;
        }
    }


}
