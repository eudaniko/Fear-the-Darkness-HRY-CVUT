using System;
using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Boss
{
    public class BossHealth : MonoBehaviour
    {
        [SerializeField] private float hp;
        [SerializeField] private ScenesManager gameManager;
        [SerializeField] private ScreenShake screenShake;
        private AudioSource _audioSource;
        
        public void ChangeHpValue(float newHp)
        {
            hp = newHp;
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void TakeDamage(float points)
        {
            if(screenShake == null) return;
            screenShake.ShakeScreen();
            _audioSource.Play();
            //TODO: add animation
            /*hp -= points;
            if (hp <= 0)
            {
                ScenesManager.FinishRun();
            }*/
        }
    }
}
