using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Creatures;
using C5;
using Commands;
using AI;
using UnityEngine.Assertions;
using Utils;

namespace ActionControl
{
    public class TurnQueue : MonoBehaviour
    {
        [SerializeField]
        private IntervalHeap<Tuple<float, Creature, CreatureMind>> queue;
        public Commander commander;

        private float _nextTurnTime = 0;
        public float NextTurnTime
        {
            get => _nextTurnTime;
        }
        
        private void Awake()
        {
            commander = GameObject.Find("ActionControl").GetComponent<Commander>();
        }

        public TurnQueue()
        {
            queue = new IntervalHeap<Tuple<float, Creature, CreatureMind>>(
                new PriorityCompare<Creature,CreatureMind>());
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
            Debug.Log($"{time}, {creature}");
            var command = creatureMind.GetNextAction();
            
            commander.ExecuteCommand(creature, command);
            queue.Add(new Tuple<float, Creatures.Creature, CreatureMind>(time + 1, creature, creatureMind));
            _nextTurnTime = queue.FindMin().Item1;
        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}