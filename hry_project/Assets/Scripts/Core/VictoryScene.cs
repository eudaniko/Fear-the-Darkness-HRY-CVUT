using UnityEngine;

namespace FtDCode.Core
{
    public class VictoryScene : MonoBehaviour
    {
        private void Awake()
        {
            PlayerPrefs.DeleteKey("Checkpoint");
        }
    }
}
