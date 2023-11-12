using UnityEngine;

namespace FtDCode.Obstacle
{
    public class Destructible : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Destroy(gameObject);
        }
    }
}
