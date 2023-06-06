using UnityEngine;
using Utils;

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
            int backwardForwardFlips, int leftRightFlips, bool rotate)
        {
            this._transform = transform;
            _modelTransform = transform.GetChild(0);
            
            this._startPosition = transform.position;
            this._endPosition = endPosition;
            
            this._startRotation = transform.rotation;
            this._endRotation = rotate ? 
                Quaternion.LookRotation(Math.DropY(endPosition - _startPosition), Vector3.up)
                : _startRotation;
            Debug.Log($"start rotation: {_startRotation}");
            Debug.Log($"end rotation: {_endRotation}");

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
            bool rotate = true
        ) : this(
            transform,
            terrain.MapToWorld(endPosition),
            duration,
            backwardForwardFlips,
            leftRightFlips,
            rotate
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
            // _modelTransform.localEulerAngles += new Vector3(
            //     _leftRightFlips * 360 * relativeTimeDelta,
            //      -_backwardForwardFlips * 360 * relativeTimeDelta,
            //      0);
            // TODO: почему-то этот код не работает, когда нужно вращать по двум осям одновременно.
            _modelTransform.Rotate(- _backwardForwardFlips * 360 * relativeTimeDelta, 0, 0, Space.Self);
            _modelTransform.Rotate(0,0, _leftRightFlips * 360 * relativeTimeDelta, Space.Self);
        }

        public override void CorrectRotation()
        {
            _modelTransform.localRotation = Quaternion.identity;
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