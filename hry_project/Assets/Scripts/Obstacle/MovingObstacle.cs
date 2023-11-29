using UnityEngine;

namespace FtDCode.Obstacle
{
    public class MovingObstacle : MonoBehaviour
    {
        [SerializeField] float speed;
        private const int ObstacleLayer = 12;
        private Rigidbody2D _rigidbody;
        
        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = FindVelocityByDirection();
        }

        private Vector2 FindVelocityByDirection()
        {
            var direction = transform.rotation.eulerAngles.z + 90;
            return new Vector2(Mathf.Cos(direction * Mathf.Deg2Rad), Mathf.Sin(direction * Mathf.Deg2Rad)) * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != ObstacleLayer) return;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
