using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ventilation : MonoBehaviour
{
    public GameObject throughtVentilationObject;
    public bool canEnterVentilation;
    public Vector3 ventilationExitPosition;
    public KeyCode useVentilationKey;
    public string playerShowingText;
    public Text playerShowingTextUI;

    private void Start()
    {
        canEnterVentilation = false;
    }

    private void Update()
    {
        if (canEnterVentilation)
        {
            if (Input.GetKeyDown(useVentilationKey))
            {
                throughtVentilationObject.transform.position = ventilationExitPosition;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canEnterVentilation = true;
            playerShowingTextUI.text = playerShowingText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canEnterVentilation = false;
            playerShowingTextUI.text = "";
        }
    }


}
