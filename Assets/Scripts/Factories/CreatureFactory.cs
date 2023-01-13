using System;
using Creatures;
using UnityEngine;
using Terrain = Landscape.Terrain;


namespace Factories
{
    public class CreatureFactory: MonoBehaviour
    {
        public Terrain terrain;
        
        public Rabbit rabbitPrefab;

        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        }

        public Rabbit CreateRabbit(Vector2Int coords)
        {
            var rabbit = Instantiate(rabbitPrefab, terrain.MapToWorld(coords), Quaternion.identity);
            transform.SetParent(GameObject.Find("Creatures").transform);
            rabbit.Init(coords);
            return rabbit;
        }
    }
}