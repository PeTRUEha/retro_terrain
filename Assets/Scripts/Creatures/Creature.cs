using System;
using UnityEngine;
using Landscape;
using UnityEditor.UI;
using Terrain = Landscape.Terrain;

namespace Creatures
{
    public class Creature: MonoBehaviour
    {
        protected Vector2Int _mapCoords;
        public Terrain terrain;

        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        }

        [property: SerializeField]
        public Vector2Int MapCoords
        {
            get => new (_mapCoords.x, _mapCoords.y);
            set
            {
                _mapCoords = new Vector2Int(value.x, value.y);
                var worldCoords = terrain.MapToWorld(_mapCoords);
                transform.SetPositionAndRotation(worldCoords, Quaternion.identity);
            }
        }
        
        void Start()
        {
        }
    }
}
