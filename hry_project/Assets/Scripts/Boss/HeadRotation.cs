using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Boss
{
    public class HeadRotation : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        
        
        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            var angle = AngleCalculator.CalculateAngle(transform.position, playerTransform.position);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, AngleCalculator.UnityToTrigonometric(angle)));
        }
        
        public void ResetRotation()
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
