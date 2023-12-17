using FtDCode.Boss;
using UnityEngine;

namespace FtDCode.Level
{
    public class BossAttackTrigger : MonoBehaviour
    {
        [SerializeField] private bool isTurningOn;

        private void OnTriggerEnter2D(Collider2D other)
        {
            BossMovement.BossAttack = isTurningOn;
            HeadAttack.IsEnabled = isTurningOn;


        }
    }
}
