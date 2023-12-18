using System;
using FtDCode.Player;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class HealingObstacle : MonoBehaviour, IInteractable
    {
        private Animator _animator;
        private static readonly int Active = Animator.StringToHash("Active");
        private AudioSource _audioSource;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void Interact(GameObject player)
        {
            _audioSource.Play();
            player.GetComponent<PlayerHealth>().SetHpToMax();
            _animator.SetBool(Active, false);

            
        }
    }
}