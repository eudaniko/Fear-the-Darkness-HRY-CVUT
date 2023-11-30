using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FtDCode.Debug
{
    public class DebugLight : MonoBehaviour
    {
        [SerializeField] private float lightIntensity;
        private Light2D _globalLight;

        private void Awake()
        {
            _globalLight = GetComponent<Light2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)) ToggleLight();
        }

        private void ToggleLight()
        {
            _globalLight.intensity = _globalLight.intensity == 0 ? lightIntensity : 0;
        }
    }
}