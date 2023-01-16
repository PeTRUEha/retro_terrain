using System;
using UnityEngine;
using Terrain = Landscape.Terrain;

namespace Movement
{
    public abstract class Moveset: MonoBehaviour
    {
        [NonSerialized]
        public float totalRotationTime = 0.25f;
        public Terrain terrain;

        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        }
    }
}