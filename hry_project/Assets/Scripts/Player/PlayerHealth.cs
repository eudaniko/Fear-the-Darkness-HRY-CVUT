using System;
using UnityEngine;
using FtDCode.Core;
using UnityEngine.Rendering.Universal;

namespace FtDCode.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private ScenesManager gameManager;
        [SerializeField] private float hp;
        [SerializeField] private Light2D torchLight;

        private void Awake()
        {
            torchLight.intensity = hp;
        }

        public void ChangeHpValue(float deltaHp)
        {
            hp += deltaHp;
            torchLight.intensity = hp;
            if ( hp<= 0)
            {
                gameManager.GameOver();
            }
        }
    }
}