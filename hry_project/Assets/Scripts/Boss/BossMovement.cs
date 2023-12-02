using UnityEngine;
using System;

namespace FtDCode.Boss
{
    public class BossMovement : MonoBehaviour
    {
        [SerializeField] private float defaultVerticalSpeed;
        private float verticalSpeed;
        private float defaultBossDistance;
        private float lastDistance;
        private float actualDistance;
        private Rigidbody2D _rigidbody;
        private Transform bossPosition;
        [SerializeField] private float needTimeForResetBoss = 6f;
        private float _deltaTime;
        [SerializeField] private Transform characterPosition;

        private void Awake()
        {
            verticalSpeed = defaultVerticalSpeed;
            _rigidbody = GetComponent<Rigidbody2D>();
            bossPosition = GetComponent<Transform>();
            defaultBossDistance = Mathf.Abs(bossPosition.position.y - characterPosition.position.y);
        }

        private void FixedUpdate()
        {
            MoveRigidbody();
            actualDistance = Mathf.Round(Mathf.Abs(bossPosition.position.y - characterPosition.position.y));
            if (actualDistance < defaultBossDistance && lastDistance == actualDistance)
            {
                lastDistance = actualDistance;
                _deltaTime += Time.deltaTime;
                if (_deltaTime >= needTimeForResetBoss)
                {
                    ChangeBossSpeed(-0.02f);
                }
            }
            else if(lastDistance != actualDistance)
            {
                ResetBossSpeed();
                lastDistance = actualDistance;
                _deltaTime = 0;
            }
            else if (actualDistance > defaultBossDistance && lastDistance == actualDistance)
            {
                lastDistance = actualDistance;
                _deltaTime += Time.deltaTime;
                if (_deltaTime >= needTimeForResetBoss)
                {
                    ChangeBossSpeed(0.02f);
                }
            }
        }

        private void MoveRigidbody()
        {
            _rigidbody.velocity = new Vector2(0, verticalSpeed);
        }

        private void ChangeBossSpeed(float deltaSpeed)
        {
            if (verticalSpeed >= 0)
            {
                verticalSpeed += deltaSpeed;
            }
        }

        private void ResetBossSpeed()
        {
            verticalSpeed = defaultVerticalSpeed;
        }

        public void SlowDownBoss(float slowedSpeed)
        {
            verticalSpeed = slowedSpeed;
        }
    }
}
