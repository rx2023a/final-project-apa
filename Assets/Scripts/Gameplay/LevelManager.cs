using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    private IExtinguishable[] extinguishables= new IExtinguishable[0];
    void Start()
    {
        Debug.Log(CalculateScore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void EndLevel()
    {

    }


    int CalculateScore()
    {
        var extinguishables = FindObjectsOfType<MonoBehaviour>(true).OfType<IExtinguishable>();

       /* foreach (IExtinguishable e in extinguishables)
        {
            Debug.Log(e);
        }*/
        int time = 1;
        int total = extinguishables.Count();
        int extinguished = extinguishables.Count(extinguishable => extinguishable.getState());
        return (extinguished/total)*(1/time);
    }
}
