using UnityEngine;

namespace Commands
{
    public class Command
    {
    }

    public class MoveCommand: Command
    {
        public MoveCommand(Creatures.Creature creature, Vector2Int direction, float cost)
        {
            this.creature = creature;
            this.direction = direction;
            this.cost = cost;
        }
        public Creatures.Creature creature; //TODO: use interface instead of class
        public Vector2Int direction;
        public float cost;
    }
    
    public class WaitCommand: Command
    {
        public WaitCommand(Creatures.Creature creature, float cost)
        {
            this.creature = creature;
            this.cost = cost;
        }
        public Creatures.Creature creature; //TODO: use interface instead of class
        public Vector2Int direction;
        public float cost;
    }

}

