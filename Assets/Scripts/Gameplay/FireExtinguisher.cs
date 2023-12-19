using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public bool activated { private get; set; }
    [SerializeField] private ParticleSystem foamParticle;
    private void Awake()
    {
        foamParticle = GetComponent<ParticleSystem>();
    }
    public void Activate()
    {
        if (activated)
        {
            foamParticle.Play();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        //other.gameObject.CompareTag(extinguishableTag)
        if (other.TryGetComponent<IExtinguishable>(out IExtinguishable extinguishable)&&activated)
        {
            Debug.Log(other.gameObject.name);
            extinguishable.Extinguish(); 
        }
    }


}
