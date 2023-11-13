using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Boss
{
    public class BossTriggerCollision : MonoBehaviour
    {
        [SerializeField] private ScenesManager gameManager;

        private Animator _animator;

        private BossMovement _boss;
        [SerializeField] private float deltaVerticalSlow;
        [SerializeField] private float deltaHorizontalSlow;

        private BossHealth _bossHealth;
        
        /*
        private static readonly string BurningObstacle = "Box";
        
        private void Awake()
        {
            _boss = GetComponent<BossMovement>();
            _animator = GetComponent<Animator>();
            _bossHealth = GetComponent<BossHealth>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(BurningObstacle))
            {
                _animator.SetBool("isSlowed", true);
                _bossHealth.TakeDamage(1);
                other.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(BurningObstacle))
            {
                _boss.ResetBossSpeed();
                _animator.SetBool("isSlowed", false);
            }

        }
        */
    }
}