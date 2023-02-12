using Creatures;
using UnityEngine;
using UnityEngine.Assertions;

namespace Commands
{
    public class JumpCommand : Command
    {
        /// <summary>
        /// Прыжок на несколько клеток
        /// </summary>
        public Vector2Int direction;

        public JumpCommand(Creature creature, Vector2Int direction, float duration)
        {
            this.creature = creature;
            this.direction = direction;
            this.duration = duration;
        }

        public override void Validate()
        {
            // TODO: в будущем движимость должна определяться реализацией интерфейса IMovable, а не класса Animal
            Assert.IsTrue(creature is Animal);
            
            Assert.IsTrue(direction.magnitude > 1);

            var newMapCoords = creature.MapCoords + direction;
            Assert.IsTrue(Map.IsWalkableAndVacant(newMapCoords));
        }

        public override void Execute()
        {
            var destination = creature.MapCoords + direction;

            var animal = creature as Animal;
            animal.Move(destination, duration);
        }
    }
}