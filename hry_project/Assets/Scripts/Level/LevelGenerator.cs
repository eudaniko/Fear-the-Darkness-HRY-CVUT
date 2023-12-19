using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FtDCode.Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private bool useTestChunks;
        [SerializeField] private int initialChunkCount;
        [SerializeField] private int activeChunkCount;
        public static int LastCheckpointNumber;
        private const string ChunkFolderPath = "Chunks/Yakov";
        private const string TestFolderPath = "Chunks/Test";
        private const string CheckpointPref = "Chekpoint";
        private Transform _level;
        private Object[] _allChunks;
        private float _currentChunkPosition;
        private readonly Queue<GameObject> _activeChunks = new();
        private readonly Queue<GameObject> _inactiveChunks = new();

        private void Awake()
        {
            _allChunks = useTestChunks ? Resources.LoadAll(TestFolderPath) : Resources.LoadAll(ChunkFolderPath);
            _level = transform.parent;
            LastCheckpointNumber = PlayerPrefs.GetInt(CheckpointPref, 0);
            InitializeQueues();
        }

        private void Start()
        {
            LevelChunk.OnChunkChange += ShiftChunks;
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt(CheckpointPref, LastCheckpointNumber);
            LevelChunk.OnChunkChange -= ShiftChunks;
        }

        private void ShiftChunks()
        {
            if (_activeChunks.Count >= activeChunkCount)
            {
                DespawnChunk(_activeChunks.Dequeue());
            }
            
            var newChunk = _inactiveChunks.Dequeue();
            SpawnChunk(newChunk);
        }

        private void InitializeQueues()
        {
            for (var i = LastCheckpointNumber; i < _allChunks.Length; i++)
            {
                _inactiveChunks.Enqueue((GameObject)_allChunks[i]);
            }
            for (var i = 0; i < initialChunkCount; i++)
            {
                SpawnChunk(_inactiveChunks.Dequeue());
            }
        }

        private void SpawnChunk(GameObject chunk)
        {
            var chunkLength = chunk.GetComponent<LevelChunk>().Length;
            var spawnPosition = new Vector3(0, _currentChunkPosition + chunkLength / 2, 0);
            
            var newChunk = Instantiate(chunk, spawnPosition, transform.rotation);
            _activeChunks.Enqueue(newChunk);
            newChunk.transform.SetParent(_level);
            
            _currentChunkPosition += chunkLength;
        }

        private void DespawnChunk(GameObject chunk)
        {
            Destroy(chunk);
        }
    }
}
