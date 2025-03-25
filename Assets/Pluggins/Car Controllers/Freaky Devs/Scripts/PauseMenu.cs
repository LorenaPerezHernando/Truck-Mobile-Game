using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace GameMenu
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject PausePanel;
        private AudioSource[] audioSources;

        void Start()
        {
            // Initial setup if needed, but not necessary to get audio sources here
        }

        public void Pause()
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            PauseAllAudio();
        }

        public void Resume()
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            ResumeAllAudio();
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }

        public void Restart()
        {
            SceneManager.LoadScene("Game");
            Time.timeScale = 1;
        }

        private void PauseAllAudio()
        {
            // Update audio sources every time pause is called
            audioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audio in audioSources)
            {
                audio.Pause();
            }
        }

        private void ResumeAllAudio()
        {
            // Update audio sources every time resume is called
            audioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audio in audioSources)
            {
                audio.UnPause();
            }
        }
    }
}
