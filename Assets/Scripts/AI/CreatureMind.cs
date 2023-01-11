using System;
using UnityEngine;
using Creatures;
using Commands;
    
namespace AI
{
    public abstract class CreatureMind : MonoBehaviour
    {
        private Creature _creature;

        private void Awake()
        {
            _creature = gameObject.GetComponent<Creature>();
        }

        public abstract Command GetNextAction();
        // TODO: нужно передавать в GetNextAction инофрмацию об окружающей среде
    }
}