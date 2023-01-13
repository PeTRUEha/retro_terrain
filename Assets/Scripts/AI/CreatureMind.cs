using System;
using UnityEngine;
using Creatures;
using Commands;
using Navigation;

namespace AI
{
    public abstract class CreatureMind : MonoBehaviour
    {
        protected Creature creature;
        public Map map;

        private void Awake()
        {
            creature = gameObject.GetComponent<Creature>();
            map = GameObject.Find("Navigation").GetComponent<Map>();
        }

        public abstract Command GetNextAction();
        // TODO: нужно передавать в GetNextAction инофрмацию об окружающей среде
    }
}