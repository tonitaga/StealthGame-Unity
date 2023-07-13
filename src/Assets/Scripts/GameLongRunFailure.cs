using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLongRunFailure : MonoBehaviour
{
    [TextArea]
    public string gameFailureInfo;
    public Text gameFailureInfoUI;

    private void Update()
    {
        if (RunTimeCounter.Instance.currentRunningTimeValue() == RunTimeCounter.Instance.maxRunningTimeValue())
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0;

            gameFailureInfoUI.text = gameFailureInfo;
        }
    }
}
