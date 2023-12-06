using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour,IExtinguishable
{
    [SerializeField, Range(0f,1f)] private float currentIntensity=1f;
    float timeLastTry=0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = .1f;
    [SerializeField]private ParticleSystem [] ps = new ParticleSystem[0];
    [SerializeField] private float decreaseAmount = 0.1f;
    private float[] startIntensity = new float[0];
    private void Awake()
    {
        Debug.Log("Fire awake");
        startIntensity = new float[ps.Length];
        for (int i = 0; i < ps.Length; i++)
        {
            startIntensity[i] = ps[i].emission.rateOverTime.constant;
        }
    }
    
    public void Explode()
    {
        throw new System.NotImplementedException();
    }
    public void ChangeIntensity()
    {
        for (int i = 0; i < ps.Length; i++)
        {
            var emmision = ps[i].emission;
            emmision.rateOverTime = currentIntensity * startIntensity[i];

        }
    }
    private void Update()
    {
        if (currentIntensity<1.0f &&Time.time-timeLastTry>regenDelay)
        {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
        }
    }
    public void Extinguish()
    {
        timeLastTry = Time.time;
        currentIntensity -= decreaseAmount;
        Debug.Log("extinguishing!!!");

        ChangeIntensity();

        if (currentIntensity<=0f)
        {
            Debug.Log("extingusihed");
            Destroy(this.gameObject);
        }
    }

    public void Ignite()
    {
        throw new System.NotImplementedException();
    }

}
