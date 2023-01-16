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
            StartCoroutine(moveset.Jump(MapCoords, destination, duration));
            MapCoords = destination;
        }

    }
}
