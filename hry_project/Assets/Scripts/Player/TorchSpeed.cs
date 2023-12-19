using UnityEngine;

namespace FtDCode.Player
{
    public class TorchSpeed : MonoBehaviour
    {
        public float HorizontalSpeed { get; private set; }
        [SerializeField] float volumeMultiplayer;
        private Vector2 _lastPosition;
        private AudioSource _audioSource;

        private void Awake()
        {
            _lastPosition = transform.localPosition;
            _audioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            Vector2 currentPosition = transform.localPosition;
            HorizontalSpeed = (currentPosition - _lastPosition).magnitude;
            _lastPosition = currentPosition;
            _audioSource.volume = HorizontalSpeed * volumeMultiplayer;
        }   
    }
}