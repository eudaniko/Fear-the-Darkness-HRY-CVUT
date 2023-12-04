using FtDCode.Player;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class KillingObstacle : MonoBehaviour
    {
        protected void OnTriggerEnter2D(Collider2D other)
        {
            var health = other.GetComponent<PlayerHealth>();
            var statement = other.GetComponent<PlayerMovement>();
            if (health == null) return;
            if (statement.IsJumping) return;
            health.Kill();
        }
    }
}