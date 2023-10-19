using System;
using UnityEngine;

namespace FtDCode.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float verticalSpeed;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            MoveRigidbody();
        }

        private void MoveRigidbody()
        {
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, verticalSpeed);
        }

        public void ChangeVerticalSpeed(float deltaSpeed)
        {
            verticalSpeed += deltaSpeed;
        }
    }
}