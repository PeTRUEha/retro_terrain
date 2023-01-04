using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Creature;
using C5;
using Commands;

namespace ActionControl
{
    public class TurnQueue : MonoBehaviour
    {
        public IntervalHeap<Tuple<float, Creature.Creature, CreatureMind>> _queue;
        public Commander _commander;

        public TurnQueue()
        {
            _queue = new IntervalHeap<Tuple<float, Creature.Creature, CreatureMind>>();
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

        public void Push(float time, Creature.Creature creature, CreatureMind creatureMind)
        {
            _queue.Add(new Tuple<float, Creature.Creature, CreatureMind>(time, creature, creatureMind));
        }

        public void RunNextTurn()
        {
            var (time, creature, creatureMind) = _queue.DeleteMin();
            var command = creatureMind.GetNextAction();
            
            _commander.ExecuteCommand(creature, command);
            _queue.Add(new Tuple<float, Creature.Creature, CreatureMind>(time + 1, creature, creatureMind));
        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}