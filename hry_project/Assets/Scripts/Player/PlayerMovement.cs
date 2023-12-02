using UnityEngine;

namespace FtDCode.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float defaultHorizontalSpeed;
        [SerializeField] private float defaultVerticalSpeed;
        [SerializeField] private bool isJumping;
        public bool IsJumping => isJumping;
        private static readonly int Jump = Animator.StringToHash("Jump");
        private float _horizontalSpeed;
        private float _verticalSpeed;
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _horizontalSpeed = defaultHorizontalSpeed;
            _verticalSpeed = defaultVerticalSpeed;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger(Jump);
            }
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