using System;
using System.Collections;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Movement
{
    public class RabbitMoveset: Moveset
    {
        // TODO: movement should be dependent on terrain, while Creature should be made independent of it.
        public new float totalRotationTime = 0.25f;

        public static float JumpHeight(float jumpTime)
        {
            return jumpTime / Constants.TimeToHeightCoefficient;
        }

        public IEnumerator Jump(Vector2Int startCoords, Vector2Int targetCoords, float movementDuration)
        {
            Vector3 startPosition = terrain.MapToWorld(startCoords);
            Vector3 targetPosition = terrain.MapToWorld(targetCoords);
            
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - startPosition, Vector3.up);

            float maxJumpHeight = JumpHeight(movementDuration);
            
            float currentMovementTime = 0f;
            
            while (currentMovementTime < movementDuration)
            {
                var deltaTime = Time.deltaTime;
                currentMovementTime += deltaTime;
                transform.position =
                    Vector3.Lerp(startPosition, targetPosition, currentMovementTime / movementDuration)
                    + Vector3.up * Height(maxJumpHeight, currentMovementTime / movementDuration);
                
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation,  currentMovementTime / totalRotationTime);
                // transform.Rotate(360 * deltaTime/totalMovementTime, 0, 0, Space.Self);
                yield return null;
            }
        }
        
        
        public IEnumerator Backflip(Vector2Int startCoords, Vector2Int targetCoords, float movementDuration) {
            
            Vector3 startPosition = terrain.MapToWorld(startCoords);
            Vector3 targetPosition = terrain.MapToWorld(targetCoords);
            
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(startPosition - targetPosition, Vector3.up);
            
            float maxJumpHeight = JumpHeight(movementDuration);
            
            float currentMovementTime = 0f; //The amount of time that has passed

            while (currentMovementTime < movementDuration) {
                currentMovementTime += Time.deltaTime;
                transform.position =
                    Vector3.Lerp(startPosition, targetPosition, currentMovementTime / movementDuration)
                    + Vector3.up * Height(maxJumpHeight, currentMovementTime / movementDuration);
                
                transform.Rotate(360 * currentMovementTime/movementDuration, 0, 0, Space.Self);

                yield return null;
            }
        }
        /// <summary>
        /// Calculate current height position in a jump given max height and timeElapsed/totalJumpTime
        /// </summary>
        private static float Height(float jumpHeight, float relativeTimeElapsed)
        {
            return (1f - 4f * (relativeTimeElapsed - 0.5f) * (relativeTimeElapsed - 0.5f)) * jumpHeight;
        }

    }
}