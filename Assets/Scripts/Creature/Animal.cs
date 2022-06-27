using Terrain;
using UnityEngine;
using UnityEngine.Assertions;

namespace Creature
{
    public class Animal : Creature
    {
        /// <summary>
        /// Responsible for physical aspects of an animal: movement, HP, hunger etc.
        /// </summary>
        public bool manualControl = true;

        public void Move(Vector2Int direction)
        {
            Assert.IsTrue(direction.x is >= -1 and <= 1);
            Assert.IsTrue(direction.y is >= -1 and <= 1);
            Assert.IsTrue(direction.magnitude > 0);
            
            FlatCoords = FlatCoords + direction;
        
            Assert.IsTrue(0 <= FlatCoords.x && FlatCoords.x < navGrid.x_dim);
            Assert.IsTrue(0 <= FlatCoords.y && FlatCoords.y < navGrid.z_dim);
        
            Vector3 newPosition = navGrid.GridCoordsToWorldPosition(FlatCoords.x, FlatCoords.y);

            transform.Translate(newPosition - transform.position);
        }
        // Update is called once per frame
        void Update()
        {
            if (manualControl)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Move(new Vector2Int(1, 1));
                }
            }

        }
    }
}
