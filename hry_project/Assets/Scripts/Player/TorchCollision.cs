using FtDCode.Obstacle;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FtDCode.Player
{
    public class TorchCollision : MonoBehaviour
    {
        [Header("Interaction Settings")]
        [SerializeField] private float speedToInteract; 
        private TorchSpeed _torchSpeed;
        private GameObject _player;
        
        [Header("Particle System Settings")]
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private int particleRateInInteractMultiplier = 3;
        private ParticleSystem.EmissionModule _emission;
        
        [Header("Trail Renderer Settings")]
        [SerializeField] private float trailWidth = 0.5f;
        [SerializeField] private int defaultParticleRateMultiplier = 0;
        private TrailRenderer _trailRenderer;
        
        [Header("Trail Light Settings")]
        [SerializeField] private float lightIntensityIncrease = 0.8f;
        [SerializeField] private float lightIntensityDecrease = 0.2f;
        private Light2D _trailLight;

        [Header("Audio Settings")]
        [SerializeField] private AudioClip[] _audioClips;
        private AudioSource _audioSource;

        private void Start()
        {
            _torchSpeed = GetComponent<TorchSpeed>();
            _trailRenderer = GetComponent<TrailRenderer>();
            _trailLight = GetComponent<Light2D>();
            _audioSource = GetComponent<AudioSource>();
            _player = transform.parent.gameObject;
            _emission = _particleSystem.emission;
        }

        private void FixedUpdate()
        {
            if (_torchSpeed.HorizontalSpeed > speedToInteract) {
                _trailRenderer.startWidth = Mathf.Min(_trailRenderer.endWidth + trailWidth, 1);
                _trailLight.intensity = Mathf.Min(_trailLight.intensity + lightIntensityIncrease, 1);
                _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
                _audioSource.Play();
                if (_emission.rateOverDistanceMultiplier <= defaultParticleRateMultiplier)
                {
                    _emission.rateOverDistanceMultiplier = particleRateInInteractMultiplier;
                }
                
            }
            else {
                _trailRenderer.startWidth = Mathf.Max(_trailRenderer.endWidth - trailWidth, 0);
                _trailLight.intensity = Mathf.Max(_trailLight.intensity - lightIntensityDecrease, 0);
                if (_emission.rateOverDistanceMultiplier > defaultParticleRateMultiplier)
                {
                    _emission.rateOverDistanceMultiplier = defaultParticleRateMultiplier;
                }

            }
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            var interactable = other.gameObject.GetComponent<IInteractable>();
            if (interactable == null || _torchSpeed.HorizontalSpeed < speedToInteract) return;
            interactable.Interact(_player);
        }
    }
}
