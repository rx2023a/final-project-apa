using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExtinguishable
{
    void Ignite();
    void Extinguish();
    void ChangeIntensity();

    void Explode();
}
