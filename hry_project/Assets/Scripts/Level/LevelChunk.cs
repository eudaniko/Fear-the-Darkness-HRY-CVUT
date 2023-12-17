using System;
using UnityEngine;

namespace FtDCode.Level
{
    public class LevelChunk : MonoBehaviour
    {
        [SerializeField] private int number;
        [SerializeField] private bool isCheckpoint;
        [SerializeField] private float length;
        public float Length => length;
        public static event Action OnChunkChange;
        private Collider2D _trigger;

        private void Awake()
        {
            _trigger = GetComponent<Collider2D>();
            if (LevelGenerator.LastCheckpointNumber == number)
            {
                GetComponent<Collider2D>().enabled = false;
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            OnChunkChange?.Invoke();
            _trigger.enabled = false;
            if (!isCheckpoint) return;
            LevelGenerator.LastCheckpointNumber = number;
        }
    }
}
