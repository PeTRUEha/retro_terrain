using Movement;
using UnityEngine;

namespace Creatures
{
    public class Rabbit : Animal
    {
        public new RabbitMoveset moveset;

        private void Start()
        {
            moveset = gameObject.AddComponent<RabbitMoveset>();
        }
        public override void Move(Vector2Int destination, float duration)
        {
            faceDirection = destination - MapCoords;
            StartCoroutine(moveset.Jump(MapCoords, destination, duration));
            MapCoords = destination;
        }

        public void Backflip(Vector2Int destination, float duration)
        {
            faceDirection = MapCoords - destination;
            StartCoroutine(moveset.Backflip(MapCoords, destination, duration));
            MapCoords = destination;
        }

    }
}
