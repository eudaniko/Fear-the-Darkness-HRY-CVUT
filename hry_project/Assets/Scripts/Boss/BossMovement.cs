using UnityEngine;

namespace FtDCode.Boss
{
    public class BossMovement : MonoBehaviour
    {
        [SerializeField] private float verticalSpeed;
        private Rigidbody2D _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            MoveRigidbody();
        }
        
        private void MoveRigidbody()
        {
            _rigidbody.velocity = new Vector2(0, verticalSpeed);
        }
    }
}
