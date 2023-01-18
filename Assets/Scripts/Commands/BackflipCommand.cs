using Creatures;
using UnityEngine;
using UnityEngine.Assertions;

namespace Commands
{
    public class BackflipCommand : Command
    {
        public Vector2Int direction;
        public BackflipCommand(Creature creature, Vector2Int direction, float duration)
        {
            this.creature = creature;
            this.direction = direction;
            this.duration = duration;
        }
        
        public override void Validate()
        {
            // TODO: убрать хардкод на кролика
            Assert.IsTrue(creature is Rabbit);            
            
            Assert.IsTrue(direction.magnitude > 0);
            
            var newMapCoords = creature.MapCoords + direction;
            Assert.IsTrue(Map.IsWalkableAndVacant(newMapCoords));
        }
        
        public override void Execute()
        {
            var destination = creature.MapCoords + direction;

            var animal = creature as Rabbit;
            animal.Backflip(destination, duration);
        }
    }
}