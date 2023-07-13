using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDoorOpen : MonoBehaviour
{
    public Text papersCountUI;
    public Text keysCountUI;

    public KeyCode doorOpenKeyCode;
    public GameObject openingDoor;
    public float endOpeningOfDoorCoord;
    public float openingSpeed;

    [TextArea]
    public string doorCanBeOpenenText, doorCantBeOpenedText;
    public Text playerInfoShowUI;

    private bool doorCanBeOpened, insideTrigger;
    void Start()
    {
        doorCanBeOpened = false;
        insideTrigger = false;
    }

    void Update()
    {
        if (doorCanBeOpened)
        {
            playerInfoShowUI.text = doorCanBeOpenenText;
            if (Input.GetKey(doorOpenKeyCode))
            {
                if (openingDoor.transform.localPosition.x >= endOpeningOfDoorCoord)
                {
                    openingDoor.transform.Translate(-openingSpeed * Time.deltaTime, 0, 0);
                }
            }
        } else
        {
            if (insideTrigger)
            {
                playerInfoShowUI.text = doorCantBeOpenedText;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            insideTrigger = true;
        }
        if (other.gameObject.tag == "Player" &&
            Int32.Parse(papersCountUI.text) == 3 &&
            Int32.Parse(keysCountUI.text) == 1)
        {
            doorCanBeOpened = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorCanBeOpened = false;
            insideTrigger = false;
            playerInfoShowUI.text = "";
        }
    }
}
