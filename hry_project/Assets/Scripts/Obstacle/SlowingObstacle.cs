using FtDCode.Player;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class SlowingObstacle : MonoBehaviour
    {
        [SerializeField] private float horizontalSpeedDecrease;
        [SerializeField] private float verticalSpeedDecrease;
        private PlayerMovement _movement;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _movement = other.GetComponent<PlayerMovement>();
            if (_movement == null) return;
            DecreaseSpeed();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _movement = other.GetComponent<PlayerMovement>();
            ResetSpeed();
        }

        private void DecreaseSpeed()
        {
            if (_movement == null) return;
            _movement.DecreaseHorizontalSpeed(horizontalSpeedDecrease);
            _movement.DecreaseVerticalSpeed(verticalSpeedDecrease);
        }

        private void ResetSpeed()
        {
            if (_movement == null) return;
            _movement.ResetHorizontalSpeed();
            _movement.ResetVerticalSpeed();
        }

        private void OnDestroy()
        {
            ResetSpeed();
        }
    }
}