using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace FtDCode.Boss
{
    public class BossMovement : MonoBehaviour
    {
        [SerializeField] private float defaultDistance;
        [SerializeField] private float attackDistance;
        private float _actualDistance;
        public static bool BossAttack;
        [SerializeField] private float defaultVerticalSpeed;
        private float _deltaVerticalSpeed;
       [SerializeField] private float deltaSpeed;
        private Rigidbody2D _rigidbody;
        private Transform _bossPosition;
        [SerializeField] private Transform characterPosition;
        [SerializeField] private float TimeToResetDistance;
        private float _deltaTime;
        private BossState _currentState;
        [SerializeField] private AudioClip[] _audioClips;
        private AudioSource _audioSource;

        private enum BossState { Approaching, Retreating, Stable, Attack }

        private void Awake()
        {
            _deltaVerticalSpeed = defaultVerticalSpeed;
            _rigidbody = GetComponent<Rigidbody2D>();
            _bossPosition = transform;
            _currentState = BossState.Stable;
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            BossAttack = false;
        }

        private void FixedUpdate()
        {
            MoveRigidbody();
            CheckDistanceAndUpdateState();
            
             if (_actualDistance <= attackDistance)
             {
                 _audioSource.clip = _audioClips[1];
                 _audioSource.Play();
             }
            else if (_actualDistance <= defaultDistance)
            {
                _audioSource.clip = _audioClips[0];
                _audioSource.Play();
            }
            else if (_actualDistance > defaultDistance+1)
            {
                _audioSource.Stop();
            }
        }
        


        private void MoveRigidbody()
        {
            _rigidbody.velocity = new Vector2(0, _deltaVerticalSpeed);
        }

        private void CheckDistanceAndUpdateState()
        {
            _actualDistance = Mathf.Abs(_bossPosition.position.y - characterPosition.position.y);
            switch (_currentState)
            {
                case BossState.Stable:
                    if (BossAttack) UpdateState(BossState.Attack);   
                    else if (_actualDistance < defaultDistance) UpdateState(BossState.Retreating);
                    else if (_actualDistance >= defaultDistance)UpdateState(BossState.Approaching);
                    break;
                case BossState.Attack:
                    if (_actualDistance > attackDistance)_deltaVerticalSpeed += deltaSpeed; // Speed up
                    else ResetBossSpeed();
                    if (!BossAttack)
                    {
                        UpdateState(BossState.Stable);
                        ResetBossSpeed();
                    }
                    
                    break;

                case BossState.Retreating:
                    if (BossAttack) UpdateState(BossState.Attack);   
                    _deltaTime += Time.deltaTime;
                    if (_deltaTime >= TimeToResetDistance)
                    {
                        _deltaVerticalSpeed -= deltaSpeed; // Slow down
                        _deltaTime = 0;
                    }
                    if (_actualDistance >= defaultDistance)
                    {
                        UpdateState(BossState.Stable);
                        BossAttack = false;
                        ResetBossSpeed();
                    }
                    break;

                case BossState.Approaching:
                    if (BossAttack) UpdateState(BossState.Attack);   
                    _deltaTime += Time.deltaTime;
                    if (_actualDistance > defaultDistance && _deltaTime >= TimeToResetDistance)
                    {
                        _deltaVerticalSpeed += deltaSpeed; // Speed up
                        _deltaTime = 0;
                    }
                    if (_actualDistance <= defaultDistance )
                    {
                        UpdateState(BossState.Stable);
                        ResetBossSpeed();
                    }
                    break;
            }
        }

        private void UpdateState(BossState newState)
        {
            _currentState = newState;
            _deltaTime = 0;
        }
        

        public void ResetBossSpeed()
        {
            _deltaVerticalSpeed = defaultVerticalSpeed;
        }
        public void SlowDownBoss(float slowedSpeed, float duration)
        {
            StartCoroutine(ResetSpeedAfterDelay(slowedSpeed, duration));
        }

        private IEnumerator ResetSpeedAfterDelay(float slowedSpeed, float duration)
        {
            float originalSpeed = defaultVerticalSpeed; 
            defaultVerticalSpeed = slowedSpeed;
            _deltaVerticalSpeed = slowedSpeed;

            yield return new WaitForSeconds(duration); 

            defaultVerticalSpeed = originalSpeed; 
            ResetBossSpeed();
        }
    }
}


