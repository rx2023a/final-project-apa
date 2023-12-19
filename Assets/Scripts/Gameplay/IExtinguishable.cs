using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExtinguishable
{
    bool getState();
    void Ignite();
    void Extinguish();
    void ChangeIntensity();

    void Explode();
}
