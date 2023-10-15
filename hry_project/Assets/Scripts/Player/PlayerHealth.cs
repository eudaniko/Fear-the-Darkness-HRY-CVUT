using UnityEngine;

namespace FtDCode.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float hp;

        public void ChangeHpValue(float deltaHp)
        {
            hp += deltaHp;
        }
    }
}