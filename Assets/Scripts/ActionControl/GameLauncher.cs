using System;
using Creatures;
using UnityEngine;
using Terrain = Landscape.Terrain;
using AI;
using Factories;

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
            var rabbit = creatureFactory.CreateRabbit(new Vector2Int(2, 2));

            turnQueue.Push(0, rabbit, rabbit.GetComponent<CreatureMind>());
        }
    }
}