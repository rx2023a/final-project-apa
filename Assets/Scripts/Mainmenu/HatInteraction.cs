using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Interacted!");
            menuScreen.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
