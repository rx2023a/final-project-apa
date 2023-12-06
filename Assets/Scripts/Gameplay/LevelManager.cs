using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TimeScore))]
public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    private IExtinguishable[] extinguishables= new IExtinguishable[0];
    private TimeScore timeScore;
    void Start()
    {
        //Debug.Log(CalculateScore());
        timeScore = GetComponent<TimeScore>();
    }
    private void Update()
    {
        if (timeScore.currentTime <= 0)
        {
            timeScore.StopTimer();
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
        timeScore.StopTimer();
        SaveScore();
        LoadLevel(0);
    }

    private const string ScoreKey = "PlayerScore";

    // Save the player score
    public void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, CalculateScore());
        PlayerPrefs.Save();
    }

    int CalculateScore()
    {
        var extinguishables = FindObjectsOfType<MonoBehaviour>(true).OfType<IExtinguishable>();

       /* foreach (IExtinguishable e in extinguishables)
        {
            Debug.Log(e);
        }*/
        int time = timeScore.fastesttime;
        int total = extinguishables.Count();
        int extinguished = extinguishables.Count(extinguishable => extinguishable.getState());
        return (extinguished/total)*(1/time);
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
