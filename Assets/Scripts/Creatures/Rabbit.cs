using Movement;
using UnityEngine;

namespace Creatures
{
    public class Rabbit : Animal
    {
        public RabbitMoves moves = new();
        public override void Move(Vector2Int destination)
        {
            MapCoords = destination;
            Vector3 newPosition = terrain.MapToWorld(_mapCoords.x, _mapCoords.y);

            Quaternion rotation = Quaternion.LookRotation(newPosition - transform.position, Vector3.up);
            StartCoroutine(moves.Jump(transform, newPosition, rotation));
        }

    }
}
