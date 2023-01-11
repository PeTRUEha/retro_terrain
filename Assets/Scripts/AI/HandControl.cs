using UnityEngine;
using Landscape;
using Commands;
using Creatures;
using UnityEditor;

namespace AI
{
    public class HandControl : CreatureMind
    {
        
        private Creature _creature;
        private Vector2Int _direction = Vector2Int.zero;

        public override Command GetNextAction()
        {
            var command = new MoveCommand(_creature, _direction, 10);
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