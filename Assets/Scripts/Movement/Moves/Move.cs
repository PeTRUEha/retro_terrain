using UnityEngine;
using Terrain = Landscape.Terrain;

namespace Movement.Moves
{
    public abstract class Move
    {
        protected static Terrain terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        public float duration;
        public abstract void UpdateTransform(float time);
    }
}