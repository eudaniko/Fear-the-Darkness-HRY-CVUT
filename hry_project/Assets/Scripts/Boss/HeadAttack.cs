using UnityEngine;

namespace FtDCode.Boss
{
    public class HeadAttack : MonoBehaviour
    {
        public static bool IsEnabled;
        private Transform _headTransform;
        private Animation _headAnimation;
        private AudioSource _audioSource;

        private void Start()
        {
            IsEnabled = false;
            _headAnimation = gameObject.GetComponentInParent<Animation>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsEnabled) return;
            Attack();
            _audioSource.Play();
        }

        private void Attack()
        {
            _headAnimation.Play();
            
        }
    }
}
