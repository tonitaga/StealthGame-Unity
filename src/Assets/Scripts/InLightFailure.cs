using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InLightFailure : MonoBehaviour
{
    [TextArea]
    public string inLightFailureInfo;
    public Text inLightFailureInfoUI;
    public float secondsForFailure;

    private bool playerIsInLight;
    private float currentTimeInLight;

    private void Start()
    {
        playerIsInLight = false;
        currentTimeInLight = 0;
    }

    void Update()
    {
        if (currentTimeInLight >= secondsForFailure)
        {
            Time.timeScale = 0;
            inLightFailureInfoUI.text = inLightFailureInfo;
        }    
        if (playerIsInLight)
        {
            currentTimeInLight += Time.deltaTime;
            if (currentTimeInLight >= secondsForFailure )
            {
                currentTimeInLight = secondsForFailure;
            }
        } else
        {
            currentTimeInLight -= Time.deltaTime;
            if (currentTimeInLight < 0)
                currentTimeInLight = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsInLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsInLight = false;
        }
    }
}
