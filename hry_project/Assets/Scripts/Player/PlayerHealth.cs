using UnityEngine;
using FtDCode.Core;
using UnityEngine.Rendering.Universal;

namespace FtDCode.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private ScenesManager gameManager; 
        [SerializeField] private Light2D torchLight;
        [SerializeField] private float defaultHp;
        public float currentHp;

        private void Awake()
        {
            torchLight.intensity = defaultHp;
            currentHp = defaultHp;
        }

        public void DecreaseHpByOnePoint()
        {
            currentHp--;
            torchLight.intensity = currentHp;
            if (currentHp <= 0) gameManager.GameOver();
        }

        public void SetHpToMax()
        {
            currentHp = defaultHp;
            torchLight.intensity = currentHp;
        }

        public void Kill()
        {
            gameManager.GameOver();
        }
    }
}