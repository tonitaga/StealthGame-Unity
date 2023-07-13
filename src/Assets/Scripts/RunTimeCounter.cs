using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunTimeCounter : MonoBehaviour
{
    public KeyCode runCode;
    public KeyCode slowWalkKey;
    public float maxRunningTime;
    public Slider noiseSlider;
    private float currentRunningTime;
    public static RunTimeCounter Instance;
    private  Rigidbody theRB;

    void Start()
    {
        Instance = this;
        currentRunningTime = 0;
        theRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(runCode))
        {
            if (theRB.velocity.x != 0)
            {
                currentRunningTime += Time.deltaTime;

                if (currentRunningTime >= maxRunningTime)
                {
                    currentRunningTime = maxRunningTime;
                }
            }
        }
        else
        {
            if (Input.GetKey(slowWalkKey)) {
                currentRunningTime -= 0.25f * Time.deltaTime;
            } else
            {
                currentRunningTime -=  0.125f * Time.deltaTime;
            }
            
            if (currentRunningTime < 0)
            {
                currentRunningTime = 0;
            }
        }
        noiseSlider.value = currentRunningTime * noiseSlider.maxValue;
    }

    public float currentRunningTimeValue() { return currentRunningTime; }
    public float maxRunningTimeValue() { return maxRunningTime; }
}
