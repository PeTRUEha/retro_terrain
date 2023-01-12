using System;
using System.Collections.Generic;
using Creatures;
using UnityEngine;
using Terrain = Landscape.Terrain;


namespace Navigation
{
    public class Map: MonoBehaviour
    {
        public int xDim;
        public int zDim;
        public Terrain terrain;
        public Creature[,] ground;
        
        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        }

        private void Start()
        {
            xDim = terrain.x_dim;
            zDim = terrain.z_dim;
            ground = new Creature[xDim, zDim];
        }

        public void PrintContents()
        {
            for(var i=0; i < xDim; i++)
            {
                for (var j = 0; j < zDim; j++)
                {
                    if (ground[i, j] != null)
                    {
                        Debug.Log($"({i}, {j})");
                        Debug.Log(ground[i, j]);
                    }
                }
            }
        }
    }
}