using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class MovingObstacle : MonoBehaviour
    {
        [SerializeField] private float speed;
        private const int ObstacleLayer = 12;
        private Rigidbody2D _rigidbody;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = FindVelocityByDirection();
        }

        private Vector2 FindVelocityByDirection()
        {
            var direction = AngleCalculator.UnityToTrigonometric(transform.rotation.eulerAngles.z);
            return new Vector2(Mathf.Cos(direction * Mathf.Deg2Rad), 
                Mathf.Sin(direction * Mathf.Deg2Rad)) * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != ObstacleLayer || _rigidbody == null) return;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
