using FtDCode.Player;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class AvoidableKillingObstacle : KillingObstacle
    {
        private new void OnTriggerEnter2D(Collider2D other)
        {
            var movement = other.gameObject.GetComponent<PlayerMovement>();
            if(movement == null || movement.IsJumping || movement.enabled == false) return;
            base.OnTriggerEnter2D(other);
        }
    }
}
