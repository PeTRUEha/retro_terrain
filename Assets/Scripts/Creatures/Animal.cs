using Landscape;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Creatures
{
    public class Animal : Creature
    {
        /// <summary>
        /// Responsible for physical aspects of an animal: movement, HP, hunger etc.
        /// </summary>
        public void Move(Vector2Int destination)
        {
            MapCoords = destination;
            Vector3 newPosition = terrain.MapToWorld(_mapCoords.x, _mapCoords.y);

            Quaternion rotation = Quaternion.LookRotation(newPosition - transform.position, Vector3.up);
            StartCoroutine(Movement.MoveObject(transform, newPosition, rotation));
            // transform.Translate(newPosition - transform.position);
            // map.PrintContents();
        }
        // Update is called once per frame
        
    }
}
