using UnityEngine;
using Terrain;
using Commands;
    
namespace Creature
{
    public class CreatureMind : MonoBehaviour
    {
        public CreatureMind(Creature creature)
        {
            _creature = creature;
            _direction = Vector2Int.zero;
        }

        private Creature _creature;
        private Vector2Int _direction;

        public Command GetNextAction()
        {
            var command = new MoveCommand(_creature, _direction, 10);
            _direction = Vector2Int.zero;
            return command;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _direction = new Vector2Int(1, 1);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _direction = new Vector2Int(-1, -1);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _direction = new Vector2Int(-1, 1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _direction = new Vector2Int(1, -1);
            }
        }
    }
}