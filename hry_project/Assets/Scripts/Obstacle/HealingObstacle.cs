using System;
using FtDCode.Player;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class HealingObstacle : MonoBehaviour, IInteractable
    {
        private Animator _animator;
        private static readonly int Active = Animator.StringToHash("Active");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void Interact(GameObject player)
        {
            player.GetComponent<PlayerHealth>().SetHpToMax();
            _animator.SetBool(Active, false);

            
        }
    }
}