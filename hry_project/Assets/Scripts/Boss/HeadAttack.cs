using UnityEngine;

namespace FtDCode.Boss
{
    public class HeadAttack : MonoBehaviour
    {
        public static bool IsEnabled;
        private Transform _headTransform;
        private Animation _headAnimation;

        private void Start()
        {
            _headAnimation = gameObject.GetComponentInParent<Animation>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsEnabled) return;
            Attack();
        }

        private void Attack()
        {
            _headAnimation.Play();
        }
    }
}
