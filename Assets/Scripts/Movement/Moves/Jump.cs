using UnityEngine;

namespace Movement.Moves
{
    public class Jump: Move
    {
        private Transform _transform;
        private Transform _modelTransform;
        
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        
        private Quaternion _startRotation;
        private Quaternion _endRotation;

        private float _jumpHeight;

        private int _backwardForwardFlips;
        private int _leftRightFlips;

        private float _lastTime = 0;

        public static float timeToTurn = 0.25f;

        public Jump(Transform transform, Vector3 endPosition, float duration,
            int backwardForwardFlips, int leftRightFlips, bool isBackwards)
        {
            Debug.Log("creating Jump");
            this._transform = transform;
            _modelTransform = transform.GetChild(0);
            
            this._startPosition = transform.position;
            this._endPosition = endPosition;
            
            this._startRotation = transform.rotation;
            this._endRotation = isBackwards ? Quaternion.LookRotation(_startPosition - endPosition, Vector3.up) 
                : Quaternion.LookRotation(endPosition - _startPosition, Vector3.up);

            this._jumpHeight = MaxHeight(duration);
            this.duration = duration;

            this._backwardForwardFlips = backwardForwardFlips;
            this._leftRightFlips = leftRightFlips;
        }

        public Jump(
            Transform transform,
            Vector2Int endPosition,
            float duration,
            int backwardForwardFlips=0,
            int leftRightFlips=0,
            bool isBackwards = false
        ) : this(
            transform,
            terrain.MapToWorld(endPosition),
            duration,
            backwardForwardFlips,
            leftRightFlips,
            isBackwards
        ) {}

        public override void UpdateTransform(float time)
        {
            var relativeTimeDelta = (time - _lastTime) / duration;
            _lastTime = time;

            var relativeTime = time / duration;
            var relTurnTime = time / timeToTurn;
            
            _transform.position =
                Vector3.Lerp(_startPosition, _endPosition, relativeTime)
                + Vector3.up * Height(_jumpHeight, relativeTime);
                
            _transform.rotation = Quaternion.Slerp(_startRotation, _endRotation,  relTurnTime);
            
            _modelTransform.Rotate(- _backwardForwardFlips * 360 * relativeTimeDelta, 0, 0, Space.Self);
            _modelTransform.Rotate(0,0, _leftRightFlips * 360 * relativeTimeDelta, Space.Self);
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