using FtDCode.Boss;
using UnityEngine;

namespace FtDCode.Level
{
    public class BossAttackTrigger : MonoBehaviour
    {
        [SerializeField] private bool isTurningOn;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var boss = other.GetComponent<BossMovement>();
            if(boss == null) return;
            boss.ToggleAttack(isTurningOn);
        }
    }
}
