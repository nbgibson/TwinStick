using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

    private bool isPaused = false;
    private float fixedDeltaTime;

    private void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(1));
        print(PlayerPrefsManager.IsLevelUnlocked(2));
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            ResumeGame();
        }
        //if(Input.GetKeyDown(KeyCode.R))
        //{
        //    ResumeGame();
        //}
        
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    private void OnApplicationPause(bool pause)
    {
        isPaused = pause;
    }
}
