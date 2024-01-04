using UnityEngine;

namespace FtDCode.Core
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        private bool isPaused;

        private void Start()
        {
            pauseMenu.SetActive(false);
        }

        private void Update()
        {
            if (!Input.GetKeyDown((KeyCode.Escape))) return;
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


        private void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
            isPaused = true;
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
            isPaused = false;
        }
    }
}