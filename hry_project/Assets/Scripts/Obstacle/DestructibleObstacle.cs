using UnityEngine;
using System.Collections;


namespace FtDCode.Obstacle
{
    public class DestructibleObstacle : MonoBehaviour, IInteractable
    {
        private static readonly int Destroy = Animator.StringToHash("Destroy");
        private Animator _animator;
        private const string FireLight = "FireLight";

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Interact(GameObject player)
        {
            if (_animator != null)
            {
                _animator.SetTrigger(Destroy);
                Transform childTransform = transform.Find(FireLight);
                if (childTransform != null) childTransform.gameObject.SetActive(true);
                StartCoroutine(DestroyAfterAnimation());
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator DestroyAfterAnimation()
        {
            yield return null; // time to change the next animation clip
            float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);
            Destroy(gameObject);
        }
    }
}