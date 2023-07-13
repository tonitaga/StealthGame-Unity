using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectCycled : MonoBehaviour
{
    public float rotateSpeed;
    public Vector3 rotationAxis;

    public float minAngle;
    public float maxAngle;
    private bool isRotatingBack = false;

    void Update()
    {
        float angle = Mathf.Lerp(minAngle, maxAngle, Mathf.PingPong(Time.time * rotateSpeed, 1f));
        transform.rotation = Quaternion.AngleAxis(angle, rotationAxis);

        if (angle == minAngle)
        {
            isRotatingBack = false;
        }
        else if (angle == maxAngle)
        {
            isRotatingBack = true;
        }

        if (isRotatingBack)
        {
            float temp = minAngle;
            minAngle = maxAngle;
            maxAngle = temp;
        }
    }
}
