using UnityEngine;

namespace Commands
{
    public class Command
    {
    }

    public class MoveCommand: Command
    {
        public MoveCommand(Creature.Creature creature, Vector2Int direction, float cost)
        {
            this.creature = creature;
            this.direction = direction;
            this.cost = cost;
        }
        public Creature.Creature creature; //TODO: use interface instead of class
        public Vector2Int direction;
        public float cost;
    }

}

