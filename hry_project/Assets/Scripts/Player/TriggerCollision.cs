using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Player
{
    public class TriggerCollision : MonoBehaviour
    {
        [SerializeField] private float deltaSpeed; 
        [SerializeField] private float time;
        [SerializeField] private float objectDisableTime ;
        [SerializeField] private ScenesManager gameManager;

        private PlayerMovement _player;
        private Collider2D _otherToDisable;
        
        private const string SlowingObstacle = "SpiderWeb";
        private const string DeathWall = "DeathWall";
        private const string DeathTriangle = "DeathTriangle";
        private const string Box = "Box";
        
        
        private void Awake()
        {
            _player = GetComponent<PlayerMovement>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(DeathWall) || other.gameObject.CompareTag(DeathTriangle))
            {
                gameManager.LoadScene("GameOverMenu");
            }

            if (other.gameObject.CompareTag(Box))
            {
                _otherToDisable = other;
                Invoke(nameof(DisableOther), objectDisableTime);
            }
            
            if (other.gameObject.CompareTag(SlowingObstacle))
            {
                SlowDown();
                Invoke(nameof(ResetSpeed), time);
                _otherToDisable = other;
                Invoke(nameof(DisableOther), objectDisableTime); 
            }
        }

        private void DisableOther( )
        {
            _otherToDisable.gameObject.SetActive(false);
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