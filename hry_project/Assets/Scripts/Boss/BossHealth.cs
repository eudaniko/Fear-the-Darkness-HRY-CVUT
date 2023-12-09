using FtDCode.Core;
using UnityEngine;

namespace FtDCode.Boss
{
    public class BossHealth : MonoBehaviour
    {
        [SerializeField] private float hp;
        [SerializeField] private ScenesManager gameManager;
        
        public void ChangeHpValue(float newHp)
        {
            hp = newHp;
        }
        
        public void TakeDamage(float points)
        {
            //TODO: add animation
            hp -= points;
            if (hp <= 0)
            {
                ScenesManager.FinishRun();
            }
        }
    }
}
