using FtDCode.Player;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class DamagingObstacle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var health = other.GetComponent<PlayerHealth>();
            if (health == null) return;
            health.DecreaseHpByOnePoint();
        }
    }
}