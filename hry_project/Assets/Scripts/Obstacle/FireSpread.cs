using System;
using System.Collections;
using UnityEngine;

namespace FtDCode.Obstacle
{
    public class FireSpread : MonoBehaviour
    {
        [SerializeField] private float timeToIgnite;
        private Collider2D _ignitingCollider;


        private void Awake()
        {
            _ignitingCollider = GetComponent<Collider2D>();
            StartCoroutine(IgniteAfterTime());
        }

        private IEnumerator IgniteAfterTime()
        {
            yield return new WaitForSeconds(timeToIgnite);
            _ignitingCollider.enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var flammable = other.GetComponent<IFlammable>();
            flammable?.Ignite();
        }
    }
}