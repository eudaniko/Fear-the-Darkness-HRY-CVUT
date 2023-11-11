using UnityEngine;
using UnityEngine.SceneManagement;

namespace FtDCode.Core
{
    public class ScenesManager : MonoBehaviour
    {
        private static string gameOverScene = "GameOverMenu";
        private static string mainScene = "Main";
        private static string mainMenuScene = "MainMenu";


        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1;
        }

        public void GameOver()
        {
            LoadScene(gameOverScene);
        }

        public void StartGame()
        {
            LoadScene(mainScene);
        }

        public void BackToMainMenu()
        {
            LoadScene(mainMenuScene);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}