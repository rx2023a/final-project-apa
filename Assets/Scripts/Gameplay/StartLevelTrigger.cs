using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelTrigger : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    // Start is called before the first frame update
    [SerializeField] private GameObject endTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelManager.StartLevel();
            endTrigger.SetActive(true);
        }

    }
}
