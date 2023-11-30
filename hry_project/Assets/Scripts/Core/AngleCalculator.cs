using UnityEngine;

namespace FtDCode.Core
{
    public class AngleCalculator : MonoBehaviour
    {
        public static float CalculateAngle(Vector2 centerPosition, Vector2 otherPosition)
        {
            var direction = (centerPosition - otherPosition).normalized;
            return UnityToTrigonometric(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        }
        
        //shifts angle to match trigonometrical standards
        private static float UnityToTrigonometric(float angle)
        {
            return Mathf.Repeat(angle + 90, 360);
        }
        
    }
}
