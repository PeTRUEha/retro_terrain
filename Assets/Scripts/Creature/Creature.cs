using UnityEngine;
using Terrain;
using UnityEditor.UI;

namespace Creature
{
    public class Creature: MonoBehaviour
    {
        private Vector2Int _mapCoords;
        public Vector2Int MapCoords
        {
            get => new (_mapCoords.x, _mapCoords.y);
            set
            {
                _mapCoords = new Vector2Int(value.x, value.y);
                //TODO: when new coordinates are set, creature must move to new coordinates on terrain
            }
        }
        
        void Start()
        {
        }
    }
}
