using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
        public bool paused = false;
        [SerializeField] private Button pauseButton;
        [SerializeField] private string pausedText = "Play";
        [SerializeField] private string playingText = "Pause";

        public void Awake()
        {
                if (paused)
                {
                        Pause();
                }
        }

        public void Pause()
        {
                Time.timeScale = 0;
                paused = true;
                pauseButton.GetComponentInChildren<Text>().text = pausedText;
        }

        public void Play()
        {
                Time.timeScale = 1;
                paused = false;
                pauseButton.GetComponentInChildren<Text>().text = playingText;
        }

        public void Toggle()
        {
                if (paused == false)
                {
                        Pause();
                } else if (paused == true)
                {
                        Play();
                }
        }

        public void Restart()
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Pause();
        }
}
