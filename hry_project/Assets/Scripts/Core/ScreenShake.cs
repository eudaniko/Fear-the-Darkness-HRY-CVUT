using UnityEngine;
using Random = UnityEngine.Random;

namespace FtDCode.Core
{
    public class ScreenShake : MonoBehaviour
    {
        [SerializeField] private float initialShakeForce;
        [SerializeField] private float decreaseFactor;
        private UnityEngine.Camera _mainCamera;
        private float _currentShakeForce;
        private bool _isShaking;

        private void Awake()
        {
            _mainCamera = GetComponent<UnityEngine.Camera>();
        }

        void Update()
        {
            if(!_isShaking) return;
            if (_currentShakeForce <= 0)
            {
                _isShaking = false;
                return;
            }
            var currentPosition = _mainCamera.transform.localPosition;
            _mainCamera.transform.localPosition = currentPosition + 
                                                  (Vector3)(Random.insideUnitCircle * _currentShakeForce);
            _currentShakeForce -= decreaseFactor * Time.deltaTime;
        }
        
        public void ShakeScreen()   
        {
            _currentShakeForce = initialShakeForce;
            _isShaking = true;
        }
    }
}
