using System.Collections;
using Movement.Moves;
using UnityEngine;

namespace Movement
{
    public static class Coroutines
    {
        public static IEnumerator StartMove(Move move)
        {
            float currentMovementTime = 0f;
            Debug.Log($"current_time: {currentMovementTime} duration: {move.duration}");
            while (currentMovementTime < move.duration)
            {
                currentMovementTime += Time.deltaTime;
                move.UpdateTransform(currentMovementTime);
                yield return null;
            }
            
        }
    }
}