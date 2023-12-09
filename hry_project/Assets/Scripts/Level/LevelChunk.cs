using System;
using UnityEngine;

namespace FtDCode.Level
{
    public class LevelChunk : MonoBehaviour
    {
        [SerializeField] private float length;
        public float Length => length;
        public static event Action OnChunkChange;
        private Collider2D _trigger;

        private void Awake()
        {
            _trigger = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _trigger.enabled = false;
            OnChunkChange?.Invoke();
        }
    }
}
