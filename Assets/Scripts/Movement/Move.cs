using Creatures;
using Navigation;
using UnityEngine;
using Terrain = Landscape.Terrain;

namespace Movement
{
    public abstract class Move
    {
        protected static Terrain terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        public float duration;
        public abstract void UpdateTransform(float time);
    }
}