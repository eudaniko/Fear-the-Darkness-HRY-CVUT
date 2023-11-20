using FtDCode.Player;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class HealingObstacle : MonoBehaviour, IInteractable
    {
        public void Interact(GameObject player)
        {
            player.GetComponent<PlayerHealth>().SetHpToMax();
        }
    }
}