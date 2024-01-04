using UnityEngine;
using UnityEngine.SceneManagement;

namespace FtDCode.Core
{
    public class ScenesManager : MonoBehaviour
    {
        [SerializeField] bool isEndless;
        private const string GameOverScene = "GameOverMenu";
        private const string MainScene = "Main";
        private const string MainMenuScene = "MainMenu";
        private const string VictoryMenuScene = "VictoryMenu";
        private const string EndlessGameOverScene = "EndlessGameOverMenu";
        private const string CheckpointPref = "Checkpoint";


        private void Awake()
        {
            AudioListener.pause = false;
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1;
        }

        public static void FinishRun()
        {
            SceneManager.LoadScene(VictoryMenuScene);
        }

        public void GameOver()
        {
            LoadScene(isEndless ? EndlessGameOverScene : GameOverScene);
        }

        public void StartGame()
        {
            LoadScene(MainScene);
        }

        public void BackToMainMenu()
        {
            LoadScene(MainMenuScene);
        }
        
        public void ResetProgress()
        {
            PlayerPrefs.DeleteAll();
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}