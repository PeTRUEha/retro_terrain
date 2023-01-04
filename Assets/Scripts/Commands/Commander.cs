using UnityEngine;

namespace Commands
{
    public class Commander: MonoBehaviour
    {
        public Terrain.Terrain _terrain;
        public void ExecuteCommand(Creature.Creature creature, Command command)
        {
            if (command is MoveCommand)
            {
                //TODO: add validation
                ExecuteMoveCommand(creature, (MoveCommand)command);
            }
            
        }

        private void ExecuteMoveCommand(Creature.Creature creature, MoveCommand command)
        {
            var destination = creature.MapCoords + command.direction;
            var newPosition = _terrain.MapToWorld(destination);
            creature.MapCoords = destination;
            creature.transform.Translate(newPosition - creature.transform.position);
        }
    }
}