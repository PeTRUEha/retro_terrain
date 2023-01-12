﻿using System;
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
            rabbit.transform.SetParent(GameObject.Find("Creatures").transform);
            rabbit.MapCoords = coords;
            return rabbit;
        }
    }
}