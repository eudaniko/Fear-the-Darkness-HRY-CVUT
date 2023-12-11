using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Level
{
    public class FinishTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            ScenesManager.FinishRun();
        }
    }
}
