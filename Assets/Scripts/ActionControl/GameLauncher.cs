using System;
using Creatures;
using UnityEngine;
using Terrain = Landscape.Terrain;
using AI;
using Factories;
using Random = UnityEngine.Random;

namespace ActionControl
{

    public class GameLauncher:MonoBehaviour
    {
        public Terrain terrain;
        public TurnQueue turnQueue;
        public CreatureFactory creatureFactory;

        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
            turnQueue = GameObject.Find("ActionControl").GetComponent<TurnQueue>();
            creatureFactory = GameObject.Find("Creatures").GetComponent<CreatureFactory>();
        }

        private void Start()
        {
            for (var i = 28; i < 33; i++)
                for (var j = 28; j < 33; j++)
                {
                    var rabbit = creatureFactory.CreateRabbit(new Vector2Int(i, j));
                }

        }
    }
}