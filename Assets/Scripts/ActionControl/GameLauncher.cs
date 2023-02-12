using System;
using Creatures;
using UnityEngine;
using Terrain = Landscape.Terrain;
using AI;
using Factories;
using UnityEditor.Experimental.GraphView;
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
            for (var i = 58; i < 63; i++)
                for (var j = 58; j < 63; j++)
                {
                    if(i == 60 && j == 60)
                    {
                        creatureFactory.CreateRabbitInHat(new Vector2Int(60, 60));
                    }
                    else
                    {
                        var rabbit = creatureFactory.CreateRabbit(new Vector2Int(i, j));
                    }
                    
                }
        }
    }
}