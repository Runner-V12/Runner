using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
        public bool paused = false;

        public void Pause()
        {
                Time.timeScale = 0;
                paused = true;
        }

        public void Play()
        {
                Time.timeScale = 1;
                paused = false;
        }

        public void Toggle()
        {
                Debug.Log("toggle pause");
                if (paused == false)
                {
                        Pause();
                } else if (paused == true)
                {
                        Play();
                }
        }
}
