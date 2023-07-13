using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public GameObject canvas;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
        if (canvas.transform.rotation != Camera.main.transform.rotation)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }
}
