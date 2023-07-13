using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserDestroyer : MonoBehaviour
{
    public GameObject laser;
    public KeyCode laserDestroyKey;
    public string playerShowingText;
    public Text playerShowingTextUI;
    private bool laserCanBeDestroyed;
    private bool isAlreadyDestoyed;

    void Start()
    {
        laserCanBeDestroyed = false;
        isAlreadyDestoyed = false;
        GetComponent<AudioSource>().Stop();
    }


    void Update()
    {
        if (!isAlreadyDestoyed && laserCanBeDestroyed)
        {
            if (Input.GetKeyDown(laserDestroyKey))
            {
                GameObject.Destroy(laser);
                GetComponent<AudioSource>().Play();
                isAlreadyDestoyed = true;
                playerShowingTextUI.text = "";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            laserCanBeDestroyed = true;
            if (!isAlreadyDestoyed)
            {
                playerShowingTextUI.text = playerShowingText;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            laserCanBeDestroyed = false;
            playerShowingTextUI.text = "";
        }
    }
}
