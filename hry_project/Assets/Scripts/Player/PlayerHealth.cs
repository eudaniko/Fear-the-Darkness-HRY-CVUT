using UnityEngine;
using FtDCode.Core;
using UnityEngine.Rendering.Universal;

namespace FtDCode.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private ScenesManager gameManager;
        [SerializeField] private float maxHp;
        [SerializeField] private Light2D torchLight;
        private float _currentHp;

        private void Awake()
        {
            torchLight.intensity = maxHp;
            _currentHp = maxHp;
        }

        public void DecreaseHpByOnePoint()
        {
            _currentHp--;
            torchLight.intensity = _currentHp;
            if (_currentHp <= 0) gameManager.GameOver();
        }

        public void SetHpToMax()
        {
            _currentHp = maxHp;
            torchLight.intensity = _currentHp;
        }

        public void Kill()
        {
            gameManager.GameOver();
        }
    }
}