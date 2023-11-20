using System;
using FtDCode.Obstacle;
using UnityEngine;

namespace FtDCode.Player
{
    public class TorchCollision : MonoBehaviour
    {
        [SerializeField] private float speedToInteract;
        private TorchSpeed _torchSpeed;
        private GameObject _player;

        private void Start()
        {
            _torchSpeed = GetComponent<TorchSpeed>();
            _player = transform.parent.gameObject;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var interactable = other.gameObject.GetComponent<IInteractable>();
            if (interactable == null || _torchSpeed.HorizontalSpeed < speedToInteract) return;
            interactable.Interact(_player);
        }
    }
}
