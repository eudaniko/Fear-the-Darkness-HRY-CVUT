using UnityEngine;

namespace FtDCode.Obstacle
{
    public class MovingObstacleTrigger : MonoBehaviour
    {
        [SerializeField] private MovingObstacle minion;

        private void OnTriggerEnter2D(Collider2D other)
        {
            minion.enabled = true;
        }
    }
}
