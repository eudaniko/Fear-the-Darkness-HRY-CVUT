using UnityEngine;

namespace FtDCode.Camera
{
    public class TransformFollower : MonoBehaviour
    {
        // Follows player ignoring horizontal movement, might be replaced by the "Cinemachine"
        [SerializeField] private Transform followedTransform;
        private float _offset;
        private Vector3 _position;

        private void Awake()
        {
            _offset = followedTransform.position.y - transform.position.y;
            _position = transform.position;
        }

        private void Update()
        {
            transform.position = new Vector3(_position.x, followedTransform.position.y - _offset, _position.z);
        }
    }
}