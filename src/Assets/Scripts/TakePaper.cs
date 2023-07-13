using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePaper : MonoBehaviour
{
    [TextArea]
    public string takePaperInfo;
    public Text takePaperInfoUI;
    public Text increasePapesCountUI;

    public KeyCode takePaperKey;
    public GameObject papers;

    private bool paperCanBeTaken;
    private bool paperIsAlreadyTook;

    void Start()
    {
        paperCanBeTaken = false;
        paperIsAlreadyTook = false;
        GetComponent<AudioSource>().Stop();
    }

    void Update()
    {
        if (paperCanBeTaken && !paperIsAlreadyTook)
        {
            if (Input.GetKeyDown(takePaperKey))
            {
                Destroy(papers);
                GetComponent<AudioSource>().Play();
                increasePapesCountUI.text = (Int32.Parse(increasePapesCountUI.text) + 1).ToString();
                paperIsAlreadyTook = true;
                takePaperInfoUI.text = "";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            paperCanBeTaken = true;
            if (!paperIsAlreadyTook)
            {
                takePaperInfoUI.text = takePaperInfo;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            paperCanBeTaken = false;
            takePaperInfoUI.text = "";
        }
    }
}
