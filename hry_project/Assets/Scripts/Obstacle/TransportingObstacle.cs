using FtDCode.Player;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class TransportingObstacle : MonoBehaviour
    {
        [SerializeField] private Transform exitPoint;
        [SerializeField] private float speed;
        private const float Tolerance = 0.001f;
        private PlayerMovement _playerMovement;
        private Transform _playerTransform;
        private Collider2D _playerCollider;
        private Animator _playerAnimator;
        private bool _isMoving;
        private Vector3 _exitPointPosition;
        private AudioSource _wind;

        private void Start()
        {
            _exitPointPosition = exitPoint.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _playerMovement = other.GetComponent<PlayerMovement>();
            _playerCollider = other.GetComponent<Collider2D>();
            _playerTransform = other.transform;
            _playerAnimator = other.GetComponent<Animator>();
            _wind = other.GetComponent<AudioSource>();
            if (_playerMovement == null || _playerCollider == null || _playerTransform == null 
                || _playerAnimator == null || _wind == null || !_playerMovement.IsJumping) return;
            StartMovement();
        }

        private void StartMovement()
        {
            _playerTransform.position = transform.position;
            TogglePlayerMovingState(true);
        }

        private void Update()
        {
            if (!_isMoving) return;
            if (!MovePlayer()) TogglePlayerMovingState(false);
        }

        private bool MovePlayer()
        {
            var step = speed * Time.deltaTime;
            var playerPosition = _playerTransform.position;
            playerPosition = Vector3.MoveTowards(playerPosition, _exitPointPosition, step);
            _playerTransform.position = playerPosition;
            return Vector3.Distance(playerPosition, _exitPointPosition) > Tolerance;
        }

        private void TogglePlayerMovingState(bool state)
        {
            _playerMovement.enabled = !state;
            _playerCollider.enabled = !state;
            _isMoving = state;
            if (state)
            {
                _wind.Play();
                _playerAnimator.speed = 0;
            }
            else
            {
                _wind.Stop();
                _playerAnimator.speed = 1;
            }
        }
    }
}