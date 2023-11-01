using UnityEngine;
using UnityEngine.SceneManagement;

namespace FtDCode.Core
{
    public class ScenesManager:MonoBehaviour
    {
        public void Reload()
        {
            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
            
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}