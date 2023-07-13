using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{
    [TextArea]
    public string winGameInfo;
    public Text winGameInfoUI;

    private bool insideWinTrigger;
    void Start()
    {
        insideWinTrigger = false;   
    }

    void Update()
    {
        if (insideWinTrigger)
        {
            winGameInfoUI.text = "Time: " + Time.timeSinceLevelLoad + "\n";
            winGameInfoUI.text += winGameInfo;
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            insideWinTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            insideWinTrigger = false;
        }
    }
}
