using Movement;
using Movement.Moves;
using UnityEngine;

namespace Creatures
{
    public class RabbitInHat : Animal
    {
        public override void Move(Vector2Int destination, float duration)
        {
            var direction = destination - MapCoords;

            Jump move;
            if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 45)
            {
                move = new Jump(transform, destination, duration, backwardForwardFlips: 0, leftRightFlips: 0);
                faceDirection = direction;
            }
            else if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 90)
            {
                move = new Jump(transform, destination, duration, backwardForwardFlips: 0, leftRightFlips: 1,  rotate:false);
            }
            else if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 135)
            {
                move = new Jump(transform, destination, duration, backwardForwardFlips: 0, leftRightFlips: 0);
                faceDirection = direction;
            }
            else if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 180)
            {
                move = new Jump(transform, destination, duration, backwardForwardFlips: -2, leftRightFlips: 0,  rotate:false);
            }
            else if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 225)
            {
                move = new Jump(transform, destination, duration, backwardForwardFlips: 0, leftRightFlips: 0);
                faceDirection = direction;
            }
            else if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 270)
            {
                move = new Jump(transform, destination, duration, backwardForwardFlips: 0, leftRightFlips: -1, rotate: false);
            }
            else if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 315)
            {
                move = new Jump(transform, destination, duration, backwardForwardFlips: 0, leftRightFlips: 0);
                faceDirection = direction;
            }
            else
            {
                move = new Jump(transform, destination, duration, backwardForwardFlips: 1, rotate:false);
            }
            Debug.Log($"up: {transform.up}" );
            StartCoroutine(Coroutines.StartMove(move));
            MapCoords = destination;
        }
    }
}