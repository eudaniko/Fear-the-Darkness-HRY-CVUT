using UnityEngine;

namespace FtDCode.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        
        [SerializeField] private float horizontalSpeed;
        private float deltaHorizontalSpeed;
        [SerializeField] private float minHorizontalSpeed;
        [SerializeField] private float verticalSpeed;
        [SerializeField] private float minVerticalSpeed;
        private float deltaVerticalSpeed;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            deltaHorizontalSpeed = horizontalSpeed;
            deltaVerticalSpeed = verticalSpeed;
        }
        
        private void FixedUpdate()
        {
            MoveRigidbody();
        }

        private void MoveRigidbody()
        {
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * deltaHorizontalSpeed, deltaVerticalSpeed);
        }

        public void ChangeVerticalSpeed(float deltaSpeed)
        {
            if (deltaVerticalSpeed >= minVerticalSpeed)
            {
                deltaVerticalSpeed += deltaSpeed;
            }
        }

        public void ChangeHorizontalSpeed(float deltaSpeed)
        {
            if (deltaHorizontalSpeed >= minHorizontalSpeed)
            {
                deltaHorizontalSpeed += deltaSpeed;
            }
        }

        public void ResetSpeed()
        {
            deltaHorizontalSpeed = horizontalSpeed;
            deltaVerticalSpeed = verticalSpeed;
        }
    }
}