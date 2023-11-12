using UnityEngine;

namespace FtDCode.Player
{
    public class TorchSpeed : MonoBehaviour
    {
        public float HorizontalSpeed { get; private set; }
        private Vector2 _lastPosition;

        private void Awake()
        {
            _lastPosition = transform.localPosition;
        }

        private void FixedUpdate()
        {
            Vector2 currentPosition = transform.localPosition;
            HorizontalSpeed = (currentPosition - _lastPosition).magnitude;
            _lastPosition = currentPosition;
        }   
    }
}