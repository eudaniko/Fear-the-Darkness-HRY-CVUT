using UnityEngine;
using UnityEngine.Events;

namespace FtDCode.Core
{
    public class Timer:MonoBehaviour
    {
        [SerializeField] private float targetTime;
        [SerializeField] private  UnityEvent<GameObject> action;

        private void Update(){
            targetTime -= Time.deltaTime;

            if (!(targetTime <= 0.0f)) return;
            EndTimer(); 
            gameObject.SetActive(false);

        }

       private void EndTimer()
        {
            action?.Invoke(gameObject);
        }
    }
}