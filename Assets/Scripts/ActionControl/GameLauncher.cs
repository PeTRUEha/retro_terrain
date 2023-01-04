using System;
using Creature;
using UnityEngine;

namespace ActionControl
{

    public class GameLauncher:MonoBehaviour
    {
        public Rabbit rabbitPrefab;
        public Creature.Creature rabbit;
        public Terrain.Terrain terrain;
        public CreatureMind creatureMind;
        public TurnQueue turnQueue;
        public TimeController timeController;
        
        private void Start()
        {
            rabbit = Instantiate(rabbitPrefab, terrain.MapToWorld(2, 2), Quaternion.identity);
            rabbit.MapCoords = new Vector2Int(2, 2);
            creatureMind = rabbit.GetComponent<CreatureMind>();
            
            turnQueue.Push(0, rabbit, creatureMind);
        }
    }
}