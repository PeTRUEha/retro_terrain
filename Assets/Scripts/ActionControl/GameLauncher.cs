using System;
using Creatures;
using UnityEngine;
using Terrain = Landscape.Terrain;
using AI;

namespace ActionControl
{

    public class GameLauncher:MonoBehaviour
    {
        public Rabbit rabbitPrefab;
        public Terrain terrain;
        public TurnQueue turnQueue;
        public TimeController timeController;

        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
            turnQueue = GameObject.Find("ActionControl").GetComponent<TurnQueue>();
            timeController = GameObject.Find("ActionControl").GetComponent<TimeController>();
        }

        private void Start()
        {
            // TODO: нужно как-то инкапсулировать операции, связанные с генерацией нового существа
            var rabbit = Instantiate(rabbitPrefab, terrain.MapToWorld(2, 2), Quaternion.identity);
            rabbit.MapCoords = new Vector2Int(2, 2);

            turnQueue.Push(0, rabbit, rabbit.GetComponent<CreatureMind>());
        }
    }
}