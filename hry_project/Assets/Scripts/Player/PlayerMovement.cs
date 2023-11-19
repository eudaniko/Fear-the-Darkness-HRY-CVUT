using UnityEngine;

namespace FtDCode.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float defaultHorizontalSpeed;
        [SerializeField] private float defaultVerticalSpeed;
        private float _horizontalSpeed;
        private float _verticalSpeed;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _horizontalSpeed = defaultHorizontalSpeed;
            _verticalSpeed = defaultVerticalSpeed;
        }

        private void FixedUpdate()
        {
            MoveRigidbody();
        }

        private void MoveRigidbody()
        {
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _horizontalSpeed, _verticalSpeed);
        }

        public void DecreaseHorizontalSpeed(float deltaSpeed)
        {
            if (_horizontalSpeed != defaultHorizontalSpeed) return;
            _horizontalSpeed -= deltaSpeed;
        }

        public void DecreaseVerticalSpeed(float deltaSpeed)
        {
            if (_verticalSpeed != defaultVerticalSpeed) return;
            _verticalSpeed -= deltaSpeed;
        }

        public void ResetHorizontalSpeed()
        {
            _horizontalSpeed = defaultHorizontalSpeed;
        }

        public void ResetVerticalSpeed()
        {
            _verticalSpeed = defaultVerticalSpeed;
        }
    }
}