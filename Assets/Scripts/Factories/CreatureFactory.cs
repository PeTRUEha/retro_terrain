using System;
using ActionControl;
using AI;
using Creatures;
using UnityEngine;
using Random = UnityEngine.Random;
using Terrain = Landscape.Terrain;


namespace Factories
{
    public class CreatureFactory: MonoBehaviour
    {
        public Terrain terrain;
        public TurnQueue turnQueue;
        public Rabbit rabbitPrefab;
        public RabbitInHat rabbitInHatPrefab;

        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
            turnQueue = GameObject.Find("ActionControl").GetComponent<TurnQueue>();
        }

        public Rabbit CreateRabbit(Vector2Int coords)
        {
            var rabbit = Instantiate(rabbitPrefab, terrain.MapToWorld(coords), Quaternion.identity);
            rabbit.transform.SetParent(GameObject.Find("Creatures").transform);
            turnQueue.Push(Time.time + Random.value * 1f, rabbit, rabbit.GetComponent<CreatureMind>());
            rabbit.Init(coords);
            return rabbit;
        }
        public RabbitInHat CreateRabbitInHat(Vector2Int coords)
        {
            var rabbit = Instantiate(rabbitInHatPrefab, terrain.MapToWorld(coords), Quaternion.identity);
            rabbit.transform.SetParent(GameObject.Find("Creatures").transform);
            turnQueue.Push(Time.time + Random.value * 1f, rabbit, rabbit.GetComponent<CreatureMind>());
            rabbit.Init(coords);
            return rabbit;
        }
    }
}