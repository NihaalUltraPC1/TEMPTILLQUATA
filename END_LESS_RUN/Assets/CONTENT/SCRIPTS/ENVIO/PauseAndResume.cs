using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour {

    public bool pause;

    void Start()
    {
        pause = false;

    }


    public void OnPause()
    {
        pause = !pause;
        if (!pause)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }
}
