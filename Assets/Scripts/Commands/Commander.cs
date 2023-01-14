using System;
using Creatures;
using Landscape;
using Navigation;
using UnityEngine;
using UnityEngine.Assertions;


namespace Commands
{
    public class Commander: MonoBehaviour
    {
        /// <summary>
        /// Валидирует и выпонляет команды, поступающие существам.
        /// </summary>
        public Map map;

        private void Awake()
        {
            map = GameObject.Find("Navigation").GetComponent<Map>();
        }

        public void ExecuteCommand(Creature creature, Command command)
        {
            if (command is MoveCommand moveCommand)
            {
                ValidateMoveCommand(creature, moveCommand);
                ExecuteMoveCommand(creature, moveCommand);
            }
            else if (command is WaitCommand waitCommand)
            {
                ExecuteWaitCommand(creature, waitCommand);
            }
            
        }

        private void ValidateMoveCommand(Creature creature, MoveCommand command)
        {
            // TODO: в будущем движимость должна определяться реализацией интерфейса IMovable, а не класса Animal
            Assert.IsTrue(creature is Animal);            
            
            Assert.IsTrue(command.direction.x is >= -1 and <= 1);
            Assert.IsTrue(command.direction.y is >= -1 and <= 1);
            Assert.IsTrue(command.direction.magnitude > 0);
            
            var newMapCoords = creature.MapCoords + command.direction;
            Assert.IsTrue(map.IsWalkableAndVacant(newMapCoords));
        }

        private void ExecuteMoveCommand(Creatures.Creature creature, MoveCommand command)
        {
            var destination = creature.MapCoords + command.direction;

            var animal = creature as Animal;
            animal.Move(destination);
        }

        private void ExecuteWaitCommand(Creature creature, WaitCommand command)
        {
            return;
        }
    }
}