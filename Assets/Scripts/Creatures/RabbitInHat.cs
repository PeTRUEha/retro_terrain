using Movement;
using UnityEngine;

namespace Creatures
{
    public class RabbitInHat: Animal
    {
        public override void Move(Vector2Int destination, float duration)
        {
            var direction = destination - MapCoords;
            // if (direction.magnitude > 1.5f)
            // {
            //     FancyJump(destination, duration, direction);
            // }
            // else
            // {
                // StartCoroutine(moveset.Jump(MapCoords, destination, duration));
            // }
            Debug.Log($"duration: {duration}");
            var move = new Jump(transform, destination, duration, backwardForwardFlips: 1);
            StartCoroutine(Coroutines.StartMove(move));
            faceDirection = direction;
            MapCoords = destination;
        }

        // private void FancyJump(Vector2Int destination, float duration, Vector2Int direction)
        // {
        //     if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 0)
        //     {
        //         Debug.Log("DoubleFrontFlip");
        //         StartCoroutine(moveset.DoubleFrontFlip(MapCoords, destination, duration));
        //     }
        //
        //     if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 90)
        //     {
        //         Debug.Log("DoubleLeftFlip");
        //         StartCoroutine(moveset.DoubleLeftFlip(MapCoords, destination, duration));
        //     }
        //
        //     if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 180)
        //     {
        //         Debug.Log("DoubleBackFlip");
        //         StartCoroutine(moveset.Backflip(MapCoords, destination, duration));
        //     }
        //
        //     if (Vector2.Angle((Vector2)direction, (Vector2)faceDirection) == 270)
        //     {
        //         Debug.Log("DoubleRightFlip");
        //         StartCoroutine(moveset.DoubleRightFlip(MapCoords, destination, duration));
        //     }
        // }
    }
}