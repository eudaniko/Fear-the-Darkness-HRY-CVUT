using System;
using UnityEngine;

namespace FtDCode.Level
{
    public class LevelChunk : MonoBehaviour
    {
        [SerializeField] private float length;
        public float Length => length;
        public static event Action OnChunkChange;


        private void OnTriggerEnter2D(Collider2D other)
        {
            OnChunkChange?.Invoke();
        }
    }
}
