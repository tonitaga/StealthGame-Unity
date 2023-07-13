using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTaker : MonoBehaviour
{
    [TextArea]
    public string keyInfoPlayer;
    public Text keyInfoPlayerUI;
    public KeyCode takeKeyCode;
    public Text increaseKeyCountUI;

    public GameObject key;

    private bool keyCanBeTaken;
    private bool keyIsAlreadyTaked;

    private void Start()
    {
        keyCanBeTaken = false;
        keyIsAlreadyTaked = false;
        GetComponent<AudioSource>().Stop();
    }

    void Update()
    {
        if (keyCanBeTaken && !keyIsAlreadyTaked)
        { 
            if (Input.GetKeyDown(takeKeyCode))
            {
                keyIsAlreadyTaked = true;
                increaseKeyCountUI.text = (Int32.Parse(increaseKeyCountUI.text) + 1).ToString();
                Destroy(key);
                GetComponent<AudioSource>().Play();
                keyInfoPlayerUI.text = "";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keyCanBeTaken = true;
            if (!keyIsAlreadyTaked)
            {
                keyInfoPlayerUI.text = keyInfoPlayer;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keyCanBeTaken = false;
            keyInfoPlayerUI.text = "";
        }
    }

}
