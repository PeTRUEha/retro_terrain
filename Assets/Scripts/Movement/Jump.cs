using UnityEngine;

namespace Movement
{
    public class Jump: Move
    {
        private Transform transform;
        private Transform modelTransform;
        
        private Vector3 startPosition;
        private Vector3 endPosition;
        
        private Quaternion startRotation;
        private Quaternion endRotation;

        private float jumpHeight;

        private int forwardFlips;
        private int leftFlips;

        public static float rotationTime = 0.25f;

        public Jump(Transform transform, Vector3 endPosition, float duration, int forwardFlips, int leftFlips)
        {
            Debug.Log("creating Jump");
            this.transform = transform;
            modelTransform = transform.GetChild(0);
            
            this.startPosition = transform.position;
            this.endPosition = endPosition;
            
            this.startRotation = transform.rotation;
            this.endRotation = Quaternion.LookRotation(endPosition - startPosition, Vector3.up);

            this.jumpHeight = MaxHeight(duration);
            this.duration = duration;

            this.forwardFlips = forwardFlips;
            this.leftFlips = leftFlips;
        }

        public Jump(
            Transform transform,
            Vector2Int endPosition,
            float duration,
            int forwardFlips=0,
            int leftFlips=0
        ) : this(
            transform,
            terrain.MapToWorld(endPosition),
            duration,
            forwardFlips,
            leftFlips
        ) {}

        public override void UpdateTransform(float time)
        {
            var relativeTime = time / duration;
            var relativeRotationTime = time / rotationTime;
            
            transform.position =
                Vector3.Lerp(startPosition, endPosition, relativeTime)
                + Vector3.up * Height(jumpHeight, relativeTime);
                
            transform.rotation = Quaternion.Slerp(startRotation, endRotation,  relativeRotationTime);
            
            modelTransform.Rotate(- forwardFlips * 360 * relativeTime, 0, 0, Space.Self);
            modelTransform.Rotate(0,0, leftFlips * 360 * relativeTime, Space.Self);
            Debug.Log($"position {transform.position}");
            Debug.Log($"rotation {transform.rotation}");
        }
        
        private static float MaxHeight(float jumpTime)
        {
            return jumpTime * jumpTime / Constants.TimeToHeightCoefficient;
        }
        
        private static float Height(float maxHeight, float relativeTimeElapsed)
        {
            return (1f - 4f * (relativeTimeElapsed - 0.5f) * (relativeTimeElapsed - 0.5f)) * maxHeight;
        }
    }
    
}