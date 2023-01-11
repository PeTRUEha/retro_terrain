using System;
using UnityEngine;
using Creatures;
using Commands;
    
namespace AI
{
    public abstract class CreatureMind : MonoBehaviour
    {
        protected Creature creature;

        private void Awake()
        {
            creature = gameObject.GetComponent<Creature>();
        }

        public abstract Command GetNextAction();
        // TODO: нужно передавать в GetNextAction инофрмацию об окружающей среде
    }
}