using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Creatures;
using C5;
using Commands;
using AI;

namespace ActionControl
{
    public class TurnQueue : MonoBehaviour
    {
        [SerializeField]
        private IntervalHeap<Tuple<float, Creature, CreatureMind>> queue;
        public Commander commander;

        private void Awake()
        {
            commander = GameObject.Find("ActionControl").GetComponent<Commander>();
        }

        public TurnQueue()
        {
            queue = new IntervalHeap<Tuple<float, Creatures.Creature, CreatureMind>>();
        }
        void Start()
        {
            // var t = new Tuple<float, CreatureMind>(1, null);
            // var t1 = new Tuple<float, CreatureMind>(1, null);
            // Transform lifeTransform = GameObject.Find("Life").transform;
            // int creatureCount = lifeTransform.childCount;
            // for (int i = 0; i < creatureCount; i++)
            // {
            //     CreatureMind creature = lifeTransform.GetChild(i).GetComponent<CreatureMind>();
            // }
        }

        public void Push(float time, Creatures.Creature creature, CreatureMind creatureMind)
        {
            queue.Add(new Tuple<float, Creatures.Creature, CreatureMind>(time, creature, creatureMind));
        }

        public void RunNextTurn()
        {
            var (time, creature, creatureMind) = queue.DeleteMin();
            var command = creatureMind.GetNextAction();
            
            commander.ExecuteCommand(creature, command);
            queue.Add(new Tuple<float, Creatures.Creature, CreatureMind>(time + 1, creature, creatureMind));
        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}