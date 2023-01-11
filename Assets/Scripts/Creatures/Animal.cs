using Landscape;
using UnityEngine;
using UnityEngine.Assertions;

namespace Creatures
{
    public class Animal : Creature
    {
        /// <summary>
        /// Responsible for physical aspects of an animal: movement, HP, hunger etc.
        /// </summary>
        public void Move(Vector2Int destination)
        {
            _mapCoords = destination;

            Vector3 newPosition = terrain.MapToWorld(_mapCoords.x, _mapCoords.y);
            
            transform.Translate(newPosition - transform.position);
        }
        // Update is called once per frame
        
    }
}
