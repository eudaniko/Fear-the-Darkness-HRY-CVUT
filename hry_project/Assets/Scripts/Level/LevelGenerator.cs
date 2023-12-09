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
        private const string ChunkFolderPath = "Chunks/Game";
        private const string TestFolderPath = "Chunks/Test";
        private Transform _level;
        private Object[] _allChunks;
        private float _currentChunkPosition;
        private readonly Queue<GameObject> _activeChunks = new();
        private readonly Queue<GameObject> _inactiveChunks = new();

        private void Awake()
        {
            _allChunks = useTestChunks ? Resources.LoadAll(TestFolderPath) : Resources.LoadAll(ChunkFolderPath);
            _level = transform.parent;
            InitializeQueues();
        }

        private void Start()
        {
            LevelChunk.OnChunkChange += ShiftChunks;
        }

        private void OnDisable()
        {
            LevelChunk.OnChunkChange -= ShiftChunks;
        }

        private void InitializeQueues()
        {
            foreach (var chunk in _allChunks)
            {
                _inactiveChunks.Enqueue((GameObject)chunk);
            }

            for (var i = 0; i < initialChunkCount; i++)
            {
                SpawnChunk(_inactiveChunks.Dequeue());
            }
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
