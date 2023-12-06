using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    [SerializeField]private string extinguishableTag = "Extinguishable";
    private void OnParticleCollision(GameObject other)
    {
        //other.gameObject.CompareTag(extinguishableTag)
        Debug.Log(other.gameObject.name);
        if (other.TryGetComponent<IExtinguishable>(out IExtinguishable extinguishable))
        {
            extinguishable.Extinguish();
        }
    }

}
