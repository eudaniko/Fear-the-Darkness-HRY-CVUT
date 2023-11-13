using System.Collections;
using System.Collections.Generic;
using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Boss
{
    public class BossHealth : MonoBehaviour
    {
        [SerializeField] private float hp;
        [SerializeField] private ScenesManager gameManager;

        private void Awake()
        {
            hp = 100;
        }
        /*
            For testing purposes
        */
        public void ChangeHpValue(float newHp)
        {
            hp = newHp;
        }
        
        // Boss is taking damage
        public void TakeDamage(float points)
        {
            hp -= points;
            // If boss has no more HP, game is must over. WE NEED TO DECIDE, HOW IT LOOKS LIKE, maybe timer after?
            if (hp <= 0)
            {
                gameManager.GameOver();
            }
        }
    }
}
