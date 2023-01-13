using System;
using UnityEngine;
using Landscape;
using Navigation;
using UnityEditor.UI;
using UnityEngine.Assertions;
using Terrain = Landscape.Terrain;

namespace Creatures
{
    public abstract class Creature: MonoBehaviour
    {
        protected Vector2Int _mapCoords;
        public Terrain terrain; // TODO: move all terrain calls to Movement
        public Map map;

        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
            map = GameObject.Find("Navigation").GetComponent<Map>();
        }

        public void Init(Vector2Int coords)
        {
            _mapCoords = coords;
            RegisterOnMap();
        }
        
        protected void RegisterOnMap()
        {
            map.ground[_mapCoords.x, _mapCoords.y] = this;
        }

        protected void UnregisterOnMap()
        {
            map.ground[_mapCoords.x, _mapCoords.y] = null;
        }

        [property: SerializeField]
        public Vector2Int MapCoords
        {
            get => new (_mapCoords.x, _mapCoords.y);
            set
            {
                UnregisterOnMap();
                _mapCoords = new Vector2Int(value.x, value.y);
                Assert.IsTrue(map.IsGroundVacant(_mapCoords));
                // var worldCoords = terrain.MapToWorld(_mapCoords);
                // transform.SetPositionAndRotation(worldCoords, Quaternion.identity);
                RegisterOnMap();
            }
        }

        void Start()
        {
        }
    }
}
