using Movement;
using Movement.Moves;
using UnityEngine;

namespace Creatures
{
    public class Rabbit : Animal
    {
        public override void Move(Vector2Int destination, float duration)
        {
            var direction = destination - MapCoords;

            Move move;
            if (duration > 1)
            {
                move = new Jump(transform, destination, duration, backwardForwardFlips: 1, rotate:false);
            }
            else
            {
                move = new Jump(transform, destination, duration);
                faceDirection = direction;
            }

            StartCoroutine(Coroutines.StartMove(move));
            MapCoords = destination;
        }
    }
}
