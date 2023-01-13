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
        public int yDim;
        public Terrain terrain;
        public Creature[,] ground;
        
        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        }

        private void Start()
        {
            xDim = terrain.x_dim;
            yDim = terrain.z_dim;
            ground = new Creature[xDim, yDim];
        }

        public bool IsGroundVacant(Vector2Int coords)
        {
            if (AreCoordsInBounds(coords) && ground[coords.x, coords.y] == null)
            {
                return true;
            }
            return false;
        }

        private bool AreCoordsInBounds(Vector2Int coords)
        {
            if (coords.x >= 0 && coords.x < xDim && coords.y >= 0 && coords.y < yDim)
            {
                return true;
            }
            return false;
        }

        public void PrintContents()
        {
            for(var i=0; i < xDim; i++)
            {
                for (var j = 0; j < yDim; j++)
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