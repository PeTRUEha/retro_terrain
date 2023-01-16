using System;
using System.Collections;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Movement
{
    public class RabbitMoveset: Moveset
    {
        // TODO: movement should be dependent on terrain, while Creature should be made independent of it.
        public new float totalMovementTime = 0.5f;
        public new float totalRotationTime = 0.25f;

        public float JumpHeight
        {
            get => totalMovementTime / Constants.TimeToHeightCoefficient;
        }

        public IEnumerator Jump(Vector2Int startCoords, Vector2Int targetCoords)
        {
            Vector3 startPosition = terrain.MapToWorld(startCoords);
            Vector3 targetPosition = terrain.MapToWorld(targetCoords);
            
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - startPosition, Vector3.up);
            
            float currentMovementTime = 0f;
            
            while (currentMovementTime < totalMovementTime)
            {
                var deltaTime = Time.deltaTime;
                currentMovementTime += deltaTime;
                transform.position =
                    Vector3.Lerp(startPosition, targetPosition, currentMovementTime / totalMovementTime)
                    + Vector3.up * Height(JumpHeight, currentMovementTime / totalMovementTime);
                
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation,  currentMovementTime / totalRotationTime);
                // transform.Rotate(360 * deltaTime/totalMovementTime, 0, 0, Space.Self);
                yield return null;
            }
        }
        
        
        
        public IEnumerator Backflip(Transform transform, Vector3 targetPosition, Quaternion targetRotation) {
            float currentMovementTime = 0f; //The amount of time that has passed
            var startPosition = transform.position;
            var startRotation = transform.rotation;
            while (currentMovementTime < totalMovementTime) {
                currentMovementTime += Time.deltaTime;
                transform.position =
                    Vector3.Lerp(startPosition, targetPosition, currentMovementTime / totalMovementTime)
                    + Vector3.up * Height(JumpHeight, currentMovementTime / totalMovementTime);
                
                transform.Rotate(new Vector3(0,0,currentMovementTime/totalMovementTime), Space.Self);

                yield return null;
            }
        }

        private static float Height(float jumpHeight, float t)
        {
            return (1f - 4f * (t - 0.5f) * (t - 0.5f)) * jumpHeight;
        }
    }
}