using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.gameObject.name);
    }
}
