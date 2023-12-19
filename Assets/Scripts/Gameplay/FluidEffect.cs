using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidEffect : MonoBehaviour
{
    public GameObject fLiquid;
    public GameObject fLiquidMesh;

    private int fSloshSpeed = 60;
    private int fRotateSpeed = 15;
    private int difference = 25;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Slosh();
        fLiquidMesh.transform.Rotate(Vector3.up * fRotateSpeed * Time.deltaTime, Space.Self);

    }

    private void Slosh()
    {
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        Vector3 finalRotation = Quaternion.RotateTowards(fLiquid.transform.localRotation, inverseRotation, fSloshSpeed * Time.deltaTime).eulerAngles;

        finalRotation.x = ClampRotationVal(finalRotation.x, difference);
        finalRotation.z = ClampRotationVal(finalRotation.z, difference);

        fLiquid.transform.localEulerAngles = finalRotation;
    }
    private float ClampRotationVal(float value, float difference)
    {
        float returnValue = 0.0f;
        if (value>180)
        {
            returnValue = Mathf.Clamp(value, 360 - difference, 360);
        }
        else
        {
            returnValue = Mathf.Clamp(value, 0, difference);
        }
        return returnValue;
    }
}
