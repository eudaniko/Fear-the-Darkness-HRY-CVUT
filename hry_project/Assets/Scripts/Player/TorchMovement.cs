using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Player
{
    public class TorchMovement : MonoBehaviour
    {
        [SerializeField] private float deadZoneRadius;
        [SerializeField] private float torchZoneRadius;
        [SerializeField] private float torchSectorAngle;
        [SerializeField] private float smoothTime = 0.1f;

        private Transform _playerTransform;
        private Vector2 _mousePosition;
        private Vector2 _playerPosition;
        private Vector2 _velocity = Vector2.zero;
        private float _sectorRightBorder;
        private float _sectorLeftBorder;
        private UnityEngine.Camera _mainCamera;
        private Vector2 _targetPosition;

        private void Awake()
        {
            CalculateBorders();
        }

        private void Start()
        {
            _playerTransform = transform.parent;
            _mainCamera = UnityEngine.Camera.main;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void CalculateBorders()
        {
            _sectorRightBorder = 360 - torchSectorAngle / 2;
            _sectorLeftBorder = torchSectorAngle / 2;
        }

        private void Move()
        {
            _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _playerPosition = _playerTransform.position;

            var angle = CalculateMouseAngle();
            var distance = CalculateDistance();

            _targetPosition = CalculateTorchPosition(distance, angle);

            transform.position = Vector2.SmoothDamp(transform.position, _targetPosition, ref _velocity, smoothTime);
        }

        private float CalculateDistance()
        {
            var distance = Vector2.Distance(_mousePosition, _playerPosition);
            return NormalizeDistance(distance);
        }

        private float CalculateMouseAngle()
        {
            var angle = AngleCalculator.CalculateAngle(_playerPosition, _mousePosition);
            return NormalizeAngle(AngleCalculator.UnityToTrigonometric(angle));
        }

        private bool IsMouseInTorchArea(float distance)
        {
            return distance > deadZoneRadius && distance < torchZoneRadius;
        }

        private bool IsMouseInTorchSector(float angle)
        {
            return angle > _sectorRightBorder || angle < _sectorLeftBorder;
        }

        private float NormalizeAngle(float angle)
        {
            if (IsMouseInTorchSector(angle)) return angle;
            return angle > 180 ? _sectorRightBorder : _sectorLeftBorder;
        }

        private float NormalizeDistance(float distance)
        {
            if (IsMouseInTorchArea(distance)) return distance;
            var middle = (torchZoneRadius - deadZoneRadius) / 2;
            return distance > middle ? torchZoneRadius : deadZoneRadius;
        }

        private Vector2 CalculateTorchPosition(float distance, float angle)
        {
            var direction = new Vector2(-Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
            return _playerPosition + distance * direction;
        }
    }
}