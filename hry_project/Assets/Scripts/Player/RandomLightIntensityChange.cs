using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;


namespace FtDCode.Player
{
    public class RandomLightIntensityChange : MonoBehaviour
    { 
        [SerializeField] private float maxIntensityDeviation=1;
        [SerializeField] private float changeInterval = 0.1f;
        [SerializeField] private float maxRandomChangeAmount = 0.2f;
        private float _defaultLightIntensity;
        private float _currentIntensity, _deltaIntensity, _newIntensity;
        private Light2D _light2D;
        private float _timer;

        private void Start()
        {
            _light2D = GetComponent<Light2D>();
            _defaultLightIntensity = _light2D.intensity;
            _timer = changeInterval;
        }

        private void FixedUpdate()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                // Generate a random change for intensity
                _deltaIntensity = Random.Range(-maxRandomChangeAmount, maxRandomChangeAmount);

                // Get the current intensity
                _currentIntensity = _light2D.intensity;

                // Apply the change
                _newIntensity = Mathf.Clamp(_currentIntensity + _deltaIntensity,
                                            Mathf.Max(0f, _defaultLightIntensity - maxIntensityDeviation),
                                            _defaultLightIntensity);


                // Set the new intensity
                _light2D.intensity = _newIntensity;

                // Reset the timer
                _timer = changeInterval;
            }
        }
    }
}