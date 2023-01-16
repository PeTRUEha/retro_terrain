using Creatures;
using UnityEngine;

namespace Commands
{
    public class Command
    {
        public Creature creature; // TODO: remove creature?
        public float duration;
    }

    public class MoveCommand: Command
    {
        public Vector2Int direction;
        public MoveCommand(Creature creature, Vector2Int direction, float duration)
        {
            this.creature = creature;
            this.direction = direction;
            this.duration = duration;
        }
    }
    
    public class WaitCommand: Command
    {
        public WaitCommand(Creature creature, float duration)
        {
            this.creature = creature;
            this.duration = duration;
        }
    }

    public class BackflipCommand : Command
    {
        public Vector2Int direction;
        public BackflipCommand(Creature creature, Vector2Int direction, float duration)
        {
            this.creature = creature;
            this.direction = direction;
            this.duration = duration;
        }
    }

}

