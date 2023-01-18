using Creatures;
using Navigation;
using UnityEngine;
using UnityEngine.Assertions;

namespace Commands
{
    public abstract class Command
    {
        protected static readonly Map Map = GameObject.Find("Navigation").GetComponent<Map>();
        public Creature creature;
        public float duration;
        public abstract void Validate();
        public abstract void Execute();

        public void ValidateAndExecute()
        {
            Validate();
            Execute();
        }
    }
}

