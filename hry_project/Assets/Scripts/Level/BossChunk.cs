using FtDCode.Boss;
using UnityEngine;

namespace FtDCode.Level
{
    public class BossChunk : MonoBehaviour
    {
        // Truly awful stuff here, delete after POC 
        private HeadAttack _head;
        
        
        private void Awake()
        {
            _head = GameObject.FindWithTag("BossHead").GetComponent<HeadAttack>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _head.enabled = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _head.enabled = false;
        }
    }
}
