using System.Collections;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Utils
{
    public class Movement
    {
        // TODO: movement should be dependent on terrain, while Creature should be made independent of it.
        public static IEnumerator MoveObject(Transform transform, Vector3 targetPosition, Quaternion targetRotation) {
            float totalMovementTime = 1f; //the amount of time you want the movement to take
            float totalRotationTime = 0.25f;
            float jumpHeight = 0.75f;
            float currentMovementTime = 0f; //The amount of time that has passed
            var startPosition = transform.position;
            var startRotation = transform.rotation;
            while (currentMovementTime < totalMovementTime) {
                currentMovementTime += Time.deltaTime;
                transform.position =
                    Vector3.Lerp(startPosition, targetPosition, currentMovementTime / totalMovementTime)
                    + Vector3.up * Height(jumpHeight, currentMovementTime / totalMovementTime);
                
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation,  currentMovementTime / totalRotationTime);
                
                yield return null;
            }
        }

        private static float Height(float jumpHeight, float t)
        {
            return (1f - 4f * (t - 0.5f) * (t - 0.5f)) * jumpHeight;
        }
    }
}