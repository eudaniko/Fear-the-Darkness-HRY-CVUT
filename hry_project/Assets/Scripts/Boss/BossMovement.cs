using UnityEngine;


namespace FtDCode.Boss
{
    public class BossMovement : MonoBehaviour
    {
        [SerializeField] private float defaltDistance;
        [SerializeField] private float defaltVertivalSpeed;
        private float _deltaVerticalSpeed ;
        [SerializeField] private float slowingBossDelta;
        private Rigidbody2D _rigidbody;
        private Transform _bossPosition;
        [SerializeField] private Transform characterPosition;
        [SerializeField] private float needTimeForResetBoss;
        private float _deltaTime;
        private BossState _currentState;

        private enum BossState { Approaching, Retreating, Stable }

        private void Awake()
        {
            _deltaVerticalSpeed = defaltVertivalSpeed;
            _rigidbody = GetComponent<Rigidbody2D>();
            _bossPosition = transform;
            _currentState = BossState.Stable;
        }

        private void FixedUpdate()
        {
            MoveRigidbody();
            CheckDistanceAndUpdateState();
        }

        private void MoveRigidbody()
        {
            _rigidbody.velocity = new Vector2(0, _deltaVerticalSpeed);
        }

        private void CheckDistanceAndUpdateState()
        {
            float actualDistance = Mathf.Abs(_bossPosition.position.y - characterPosition.position.y);
            UnityEngine.Debug.Log(actualDistance);
            UnityEngine.Debug.Log(_currentState);
            switch (_currentState)
            {
                case BossState.Stable:
                    if (actualDistance > defaltDistance)
                    {
                        UpdateState(BossState.Stable);
                    }
                    else if (actualDistance < defaltDistance)
                    {
                        UpdateState(BossState.Retreating);
                    }
                    break;
                case BossState.Retreating:
                    if (_deltaTime >= needTimeForResetBoss)
                    {
                        UnityEngine.Debug.Log("Change speed");
                        AdjustBossSpeed();
                        _deltaTime = 0;
                    }
                    else if (actualDistance > defaltDistance)
                    {
                        UpdateState(BossState.Stable);
                        ResetBossSpeed();
                    }

                    UnityEngine.Debug.Log(_deltaTime);
                    _deltaTime += Time.deltaTime;
                    break;
            }
        }

        private void UpdateState(BossState newState)
        {
            _currentState = newState;
            _deltaTime = 0; // Reset timer when state changes
        }

        private void AdjustBossSpeed()
        {
            if (_currentState == BossState.Approaching)
            {
                ChangeBossSpeed(+slowingBossDelta);
            }
            else if (_currentState == BossState.Retreating)
            {
                ChangeBossSpeed(-slowingBossDelta);
            }
        }

        private void ChangeBossSpeed(float deltaSpeed)
        {
            _deltaVerticalSpeed += deltaSpeed;
        }

        public void ResetBossSpeed()
        {
            _deltaVerticalSpeed = defaltVertivalSpeed;
        }

        public void SlowDownBoss(float slowedSpeed)
        {
            _deltaVerticalSpeed = slowedSpeed;
        }
    }
}
