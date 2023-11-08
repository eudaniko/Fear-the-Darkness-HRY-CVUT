using UnityEngine;
using System;
using UnityEngine.Serialization;

namespace FtDCode.Boss
{
    public class BossMovement : MonoBehaviour
    {
        [SerializeField] private float defaltVerticalSpeed;
        private float verticalSpeed;
        private float defaltBossDistance;
        private double lastDistance;
        private double actualDistance;
        private Rigidbody2D _rigidbody;
        private Transform bossPosition;
        [SerializeField] private float needTimeForResetBoss = 6f;
        private float _deltaTime;
        [SerializeField] private Transform characterPosition;

        private void Awake()
        {
            verticalSpeed = defaltVerticalSpeed;
            _rigidbody = GetComponent<Rigidbody2D>();
            bossPosition = GetComponent<Transform>();
            defaltBossDistance = Math.Abs(bossPosition.position.y - characterPosition.position.y);
        }

        private void FixedUpdate()
        {
            MoveRigidbody();
            actualDistance = Math.Round(Math.Abs(bossPosition.position.y - characterPosition.position.y));
            if (actualDistance < defaltBossDistance && lastDistance == actualDistance)
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
            verticalSpeed = defaltVerticalSpeed;
        }
    }
}
