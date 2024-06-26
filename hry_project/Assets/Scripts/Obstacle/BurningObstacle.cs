﻿using System;
using FtDCode.Boss;
using FtDCode.Player;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

namespace FtDCode.Obstacle
{
    public class BurningObstacle : MonoBehaviour, IInteractable, IFlammable
    {
        [SerializeField] private float damage;
        [SerializeField] private float slowedSpeed;
        [SerializeField] private float slowingTime;
        private Collider2D _burningCollider;
        private GameObject _light;
        private SpriteRenderer _sprite;
        private const int _scoreModifier = 10;

        private void Awake()
        {
            _burningCollider = transform.GetChild(0).gameObject.GetComponent<Collider2D>();
            _light = transform.GetChild(1).gameObject;
            _sprite = GetComponent<SpriteRenderer>();
        }
        

        public void Interact(GameObject player)
        {
            _burningCollider.enabled = true;
            PlayerScore.CurrentScore += _scoreModifier;
            _light.SetActive(true);
        }
        
        public void Ignite()
        {
            Interact(null);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var bossHealth = other.gameObject.GetComponent<BossHealth>();
            var bossSpeed = other.gameObject.GetComponentInParent<BossMovement>();
            if (bossHealth == null || bossSpeed == null) return;
            bossHealth.TakeDamage(damage);
            bossSpeed.SlowDownBoss(slowedSpeed, slowingTime);
        }
    }
}