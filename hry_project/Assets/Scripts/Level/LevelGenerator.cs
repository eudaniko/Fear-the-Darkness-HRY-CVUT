using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace FtDCode.Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private bool enableEndlessGeneration;
        [SerializeField] private bool useTestChunks;
        [SerializeField] private int initialChunkCount;
        [SerializeField] private int activeChunkCount;
        [SerializeField] private AnimationCurve speedCurve;
        public static int LastCheckpointNumber;
        private const string EndlessFolderPath = "Chunks/Endless";
        private const string ChunkFolderPath = "Chunks/Game";
        private const string TestFolderPath = "Chunks/Test";
        private const string CheckpointPref = "Chekpoint";
        private const float AccelerationStep = 0.015f;
        private float _accelerationPoint = 0;
        private const float FirstChunkLength = 30;
        private Transform _level;
        private Object[] _allChunks;
        private Object[] _randomizedChunks;
        private float _currentChunkPosition;
        private readonly Queue<GameObject> _activeChunks = new();
        private readonly Queue<GameObject> _inactiveChunks = new();

        private void Awake()
        {
            if (enableEndlessGeneration)
            {
                _allChunks = Resources.LoadAll(EndlessFolderPath);
                _randomizedChunks = new Object[_allChunks.Length];
                _currentChunkPosition += FirstChunkLength;
                Shuffle();
            }
            else
            {
                _allChunks = useTestChunks ? Resources.LoadAll(TestFolderPath) : Resources.LoadAll(ChunkFolderPath);
            }
            _level = transform.parent;
            LastCheckpointNumber = PlayerPrefs.GetInt(CheckpointPref, 0);
            InitializeQueues();
        }

        private void Shuffle()
        {
            var indexes = new List<int>();
            for (int i = 0; i < _allChunks.Length; i++)
            {
                indexes.Add(i);
            }

            for (int i = 0; i < _allChunks.Length; i++)
            {
                var index = indexes[Random.Range(0, indexes.Count)];
                indexes.Remove(index);
                _randomizedChunks[i] = _allChunks[index];
            }
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
            if (_inactiveChunks.Count < 1 && enableEndlessGeneration)
            {
                Shuffle();
                for (var i = LastCheckpointNumber; i < _allChunks.Length; i++)
                {
                    _inactiveChunks.Enqueue((GameObject)_randomizedChunks[i]);
                }
            }

            if (_activeChunks.Count >= activeChunkCount)
            {
                DespawnChunk(_activeChunks.Dequeue());
            }

            var newChunk = _inactiveChunks.Dequeue();
            SpawnChunk(newChunk);
            
            if(!enableEndlessGeneration) return;
            _accelerationPoint += AccelerationStep;
            Time.timeScale = 1 + speedCurve.Evaluate(_accelerationPoint);
        }

        private void InitializeQueues()
        {
            if (enableEndlessGeneration)
            {
                for (var i = LastCheckpointNumber; i < _randomizedChunks.Length; i++)
                {
                    _inactiveChunks.Enqueue((GameObject)_randomizedChunks[i]);
                }
            }
            else
            {
                for (var i = LastCheckpointNumber; i < _allChunks.Length; i++)
                {
                    _inactiveChunks.Enqueue((GameObject)_allChunks[i]);
                }
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