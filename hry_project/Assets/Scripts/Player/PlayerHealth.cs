using System;
using UnityEngine;
using FtDCode.Core;
using UnityEngine.Rendering.Universal;

namespace FtDCode.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private ScenesManager gameManager;
        [SerializeField] private Light2D torchLight;
        private const float DefaultHp = 3;
        private const float DefaultTorchIntensity = 2;
        public float currentHp;

        private void Awake()
        {
            torchLight.intensity = DefaultTorchIntensity;
            currentHp = DefaultHp;
        }

        public void DecreaseHpByOnePoint()
        {
            currentHp--;
            torchLight.intensity -= (float)Math.Round((DefaultTorchIntensity/DefaultHp), 2);
            if (currentHp <= 0) gameManager.GameOver();
        }

        public void SetHpToMax()
        {
            currentHp = DefaultHp;
            torchLight.intensity = DefaultTorchIntensity;
        }

        public void Kill()
        {
            gameManager.GameOver();
        }
    }
}