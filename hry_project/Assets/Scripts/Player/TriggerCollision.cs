using System;
using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Player
{
    public class TriggerCollision : MonoBehaviour
    {
        [SerializeField] private ScenesManager gameManager;

        private Animator _animator;

        private PlayerMovement _player;
        [SerializeField] private float deltaVerticalSlow;
        [SerializeField] private float deltaHorizontalSlow;

        private PlayerHealth _playerHealth;
        [SerializeField] private float deltaWater;

        private static readonly string SlowingObstacle = "SpiderWeb";
        private static readonly string DeathWall = "DeathWall";
        private static readonly string DeathTriangle = "DeathTriangle";
        private static readonly string Water = "Water";


        private void Awake()
        {
            _player = GetComponent<PlayerMovement>();
            _animator = GetComponent<Animator>();
            _playerHealth = GetComponent<PlayerHealth>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(SlowingObstacle))
            {
                _animator.SetBool("isSlowed", true);
            }

            if (other.gameObject.CompareTag(Water))
            {
                _playerHealth.ChangeHpValue(deltaWater);
                other.GetComponent<CircleCollider2D>().enabled = false;
            }
        }


        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(DeathWall) || other.gameObject.CompareTag(DeathTriangle))
            {
                gameManager.GameOver();
            }
            else if (other.gameObject.CompareTag(SlowingObstacle))
            {
                _player.ChangeVerticalSpeed(deltaVerticalSlow);
                _player.ChangeHorizontalSpeed(deltaHorizontalSlow);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(SlowingObstacle))
            {
                _player.ResetSpeed();
                _animator.SetBool("isSlowed", false);
            }

        }
    }
}