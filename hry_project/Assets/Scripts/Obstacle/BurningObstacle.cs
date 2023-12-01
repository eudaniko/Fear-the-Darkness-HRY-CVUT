using FtDCode.Boss;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class BurningObstacle : MonoBehaviour, IInteractable
    {
        [SerializeField] private float damage;
        private Collider2D _burningCollider;
        private SpriteRenderer _sprite;

        private void Awake()
        {
            _burningCollider = transform.GetChild(0).gameObject.GetComponent<Collider2D>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void Interact(GameObject player)
        {
            _burningCollider.enabled = true;
            _sprite.color = Color.red;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var bossHealth = other.gameObject.GetComponent<BossHealth>();
            if (bossHealth == null) return;
            bossHealth.TakeDamage(damage);
        }
    }
}