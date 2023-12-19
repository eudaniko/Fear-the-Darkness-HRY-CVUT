using FtDCode.Core;
using FtDCode.Player;
using UnityEngine;

namespace FtDCode.Level
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private float reducingValue;
        private void OnTriggerEnter2D(Collider2D other)
        {
            var movement = other.GetComponent<PlayerMovement>();
            if(movement == null) return;
            movement.StartFinishSequence(reducingValue);
            //ScenesManager.FinishRun();
        }
    }
}
