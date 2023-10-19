using UnityEngine;

namespace FtDCode.Player
{
    public class TriggerCollision : MonoBehaviour
    {
        [SerializeField] private float deltaSpeed; 
        [SerializeField] private float time; 
        private PlayerMovement _player;
        private const string SlowingObstacle = "SpiderWeb";
        
        
        private void Awake()
        {
            _player = GetComponent<PlayerMovement>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(SlowingObstacle)) return;
            SlowDown();
            Invoke(nameof(ResetSpeed), time);
        }

        private void SlowDown()
        {
            _player.ChangeVerticalSpeed(deltaSpeed);
        }

        private void ResetSpeed()
        {
            _player.ChangeVerticalSpeed(-deltaSpeed);
        }
    }
}