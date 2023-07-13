using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource normalAudioSource, panicAudioSource, restartAudioSource;

    private void Start()
    {
        normalAudioSource.Play();
        panicAudioSource.Stop();
        restartAudioSource.Stop();
    }

    private void Update()
    {
        var runningTime = GetComponent<RunTimeCounter>();
        if (normalAudioSource.isPlaying && runningTime.currentRunningTimeValue() >= 0.5f)
        {
            normalAudioSource.Stop();
            panicAudioSource.Play();
        } else if (panicAudioSource.isPlaying && runningTime.currentRunningTimeValue() < 0.5f)
        {
            panicAudioSource.Stop();
            normalAudioSource.Play();
        }
    }
}
