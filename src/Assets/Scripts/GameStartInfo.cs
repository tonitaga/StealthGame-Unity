using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartInfo : MonoBehaviour
{
    [TextArea]
    public string startInfo;
    public Text startInfoUI;
    private bool playerIsHere;

    private void Start()
    {
        playerIsHere = false;
    }

    private void Update()
    {
        if (playerIsHere)
        {
            startInfoUI.text = startInfo;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsHere = false;
            startInfoUI.text = "";
        }
    }

}
