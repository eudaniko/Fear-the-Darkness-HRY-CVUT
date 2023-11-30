using UnityEngine;

namespace FtDCode.Core
{
    public class AngleCalculator : MonoBehaviour
    {
        private const float AngleShift = 90;
        private const float FullCirceAngle = 360;
        public static float CalculateAngle(Vector2 centerPosition, Vector2 otherPosition)
        {
            var direction = (centerPosition - otherPosition).normalized;
            return Mathf.Repeat(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, 360);
        }
        
        public static float UnityToTrigonometric(float angle)
        {
            return Mathf.Repeat(angle + AngleShift, FullCirceAngle);
        }
        
        public static float TrigonometricToUnity(float angle)
        {
            return Mathf.Repeat(angle - AngleShift, FullCirceAngle);
        }
        
    }
}
