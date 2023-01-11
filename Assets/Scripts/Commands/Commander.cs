using System;
using Creatures;
using Landscape;
using UnityEngine;
using UnityEngine.Assertions;


namespace Commands
{
    public class Commander: MonoBehaviour
    {
        /// <summary>
        /// Валидирует и выпонляет команды, поступающие существам.
        /// </summary>
        public Landscape.Terrain terrain;

        private void Awake()
        {
            terrain = GameObject.Find("Terrain").GetComponent<Landscape.Terrain>();
        }

        public void ExecuteCommand(Creature creature, Command command)
        {
            if (command is MoveCommand)
            {
                var moveCommand = (MoveCommand)command;
                ValidateMoveCommand(creature, moveCommand);
                ExecuteMoveCommand(creature, moveCommand);
            }
            
        }

        private void ValidateMoveCommand(Creature creature, MoveCommand command)
        {
            // TODO: в будущем движимость должна определяться реализацией интерфейса IMovable, а не класса Animal
            Assert.IsTrue(creature is Animal);            
            
            Assert.IsTrue(command.direction.x is >= -1 and <= 1);
            Assert.IsTrue(command.direction.y is >= -1 and <= 1);
            // Assert.IsTrue(command.direction.magnitude > 0);
            
            var newMapCoords = creature.MapCoords + command.direction;
            Assert.IsTrue(0 <= newMapCoords.x && newMapCoords.x < terrain.x_dim);
            Assert.IsTrue(0 <= newMapCoords.y && newMapCoords.y < terrain.z_dim);
        }

        private void ExecuteMoveCommand(Creatures.Creature creature, MoveCommand command)
        {
            var destination = creature.MapCoords + command.direction;

            var animal = creature as Animal;
            animal.Move(destination);
        }
    }
}