using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public GameObject openingDoor;
    public float startOpeningCoord, endOpeningCoord;
    public float openingSpeed, closingSpeed;

    public bool canBeOpened; 
    void Start()
    {
        canBeOpened = false;
        GetComponent<AudioSource>().Stop();
    }

    void Update()
    {
        if (canBeOpened)
        {
            if (openingDoor.transform.localPosition.z >= endOpeningCoord)
            {
                openingDoor.transform.Translate(-openingSpeed * Time.deltaTime, 0, 0);
            }
        } else
        {
            if (openingDoor.transform.localPosition.z <= startOpeningCoord)
            {
                openingDoor.transform.Translate(closingSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canBeOpened = true;
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canBeOpened = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
