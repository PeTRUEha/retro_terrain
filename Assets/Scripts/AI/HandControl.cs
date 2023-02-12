using UnityEngine;
using Landscape;
using Commands;
using Creatures;
using UnityEditor;

namespace AI
{
    public class HandControl : CreatureMind
    {
        private Vector2Int _direction = Vector2Int.zero;

        public override Command GetNextAction()
        {
            Command command;
            if (_direction != Vector2Int.zero)
            {
                //TODO: стоимость команды должна определяться не в модуле ИИ и должна зависить от статов и состояния
                // существа
                command = new WalkCommand(creature, _direction, 10);
            }
            else
            {
                command = new WaitCommand(creature, 10);
            }
            _direction = Vector2Int.zero;
            return command;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _direction += new Vector2Int(1, 1);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _direction += new Vector2Int(-1, -1);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _direction += new Vector2Int(-1, 1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _direction += new Vector2Int(1, -1);
            }

            if (_direction.magnitude > 1.5)
            {
                _direction /= 2;
            }
        }
    }
}