using System.Collections.Generic;
using Commands;
using Creatures;
using UnityEngine;
using Random = System.Random;

namespace AI
{
    public class RabbitInHatRandomWandering: CreatureMind
    {
        protected new RabbitInHat creature;

        private void Start()
        {
            //TODO: call parent class awake instead of using start here
            creature = gameObject.GetComponent<RabbitInHat>();
        }

        public override Command GetNextAction()
        {
            var direction = GetRandomDirection(creature.MapCoords);
            Command command;
            if (direction == Vector2Int.zero)
            {
                command = new WaitCommand(creature, 1);
            }
            else if(direction.magnitude < 1.5f)
            {
                command = new WalkCommand(creature, direction, 1);
                // TODO: duration must be determined externally. Maybe make it in Command as a property.
            }
            else
            {
                command = new JumpCommand(creature, direction, 1.5f);
            }
            return command;
        }
        private Vector2Int GetRandomDirection(Vector2Int currentPosition)
        {
            var possibleDirections = new List<Vector2Int>();
            for (var i = -1; i < 2; i++)
                for (var j = -1; j < 2; j++)
                {
                    var direction = new Vector2Int(i, j);
                    if (direction != Vector2Int.zero)
                    {
                        possibleDirections.Add(direction);
                        if (Vector2.Angle(creature.faceDirection, direction) % 90 == 0)
                            possibleDirections.Add(direction * 2);
                    }
                }

            var availableDirections = new List<Vector2Int>();
            foreach (var direction in possibleDirections)
            {
                if (map.IsWalkableAndVacant(currentPosition + direction))
                    availableDirections.Add(direction); 
            }
            var rnd = new Random();
            if (availableDirections.Count == 0)
                return Vector2Int.zero;
            var index = rnd.Next(availableDirections.Count);
            return availableDirections[index];
        }
    }    
}