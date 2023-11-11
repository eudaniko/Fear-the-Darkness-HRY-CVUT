using UnityEngine;
using UnityEngine.SceneManagement;

namespace FtDCode.Level
{
    public class ReloadLevel:MonoBehaviour
    {
        public void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            
        }
    }
}