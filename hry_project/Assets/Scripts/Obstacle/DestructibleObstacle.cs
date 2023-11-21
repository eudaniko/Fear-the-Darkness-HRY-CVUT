using UnityEngine;

namespace FtDCode.Obstacle
{
    public class DestructibleObstacle : MonoBehaviour, IInteractable
    {
        public void Interact(GameObject player)
        {
            Destroy(gameObject);
        }
    }
}
