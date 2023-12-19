using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        levelManager.EndLevel();
    }
}
