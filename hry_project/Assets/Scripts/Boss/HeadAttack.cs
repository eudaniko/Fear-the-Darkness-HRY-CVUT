using UnityEngine;

namespace FtDCode.Boss
{
    public class HeadAttack : MonoBehaviour
    {
        private Transform _headTransform;
        private Animation _headAnimation;
        private AudioSource _audioSource;

        private void Start()
        {
            _headAnimation = gameObject.GetComponentInParent<Animation>();
            _audioSource = GetComponent<AudioSource>();
            enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!enabled) return;
            Attack();
            _audioSource.Play();
        }

        private void Attack()
        {
            _headAnimation.Play();
            
        }
    }
}
