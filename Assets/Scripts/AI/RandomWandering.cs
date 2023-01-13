using System.Collections.Generic;
using UnityEngine;
using Landscape;
using Commands;
using Creatures;
using UnityEditor;
using Random = System.Random;
namespace AI
{
    public class RandomWandering: CreatureMind
    {

        public override Command GetNextAction()
        {
            var direction = GetRandomDirection(creature.MapCoords);
            Command command;
            if (direction != Vector2Int.zero)
            {
                command = new MoveCommand(creature, direction, 10);
            }
            else
            {
                command = new WaitCommand(creature, 10);
            }
            direction = Vector2Int.zero;
            return command;
        }
        private Vector2Int GetRandomDirection(Vector2Int currentPosition)
        {
            var availableDirections = new List<Vector2Int>();
            for (var i = -1; i < 2; i++)
                for (var j = -1; j < 2; j++)
                {
                    var direction = new Vector2Int(i, j);
                    if (direction == Vector2Int.zero)
                        continue;
                    if (map.IsGroundVacant(currentPosition + direction))
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