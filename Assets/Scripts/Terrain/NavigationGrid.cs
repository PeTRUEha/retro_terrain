using UnityEngine;
using UnityEngine.Assertions;

namespace Terrain
{
    public class NavigationGrid : MonoBehaviour
    {
        Vector3[,] nodes;
        bool initialized = false;

        public void Init(Vector3[,] coords){
            nodes = new Vector3[coords.GetLength(0), coords.GetLength(1)];
            for (int x = 0; x < coords.GetLength(0) - 1; x++){
                for (int z = 0; z < coords.GetLength(1) - 1; z++){
                    nodes[x, z] = (coords[x, z] + coords[x + 1, z] + coords[x, z + 1] + coords[x + 1, z + 1]) / 4;
                }
            }
            // OnDrawGizmosSelected();
            Debug.Log("initialization complete");
            initialized = true;
        }
    
        void OnDrawGizmos()
        {
            if (!initialized) return;
            foreach(Vector3 vec3 in nodes)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(vec3, .1f);
            }
        }
        public Vector3Int WorldPositionToGridCoords(Vector3 worldPosition)
        {
            Vector3 floatGridCoords = worldPosition - nodes[0, 0];
            var x = Mathf.RoundToInt(floatGridCoords.x);
            var y = Mathf.RoundToInt(floatGridCoords.z);
            var z = Mathf.RoundToInt(floatGridCoords.z / Constants.HeightCoefficient);
            return new Vector3Int(x, y);
        }

        public Vector3 GridCoordsToWorldPosition(Vector3Int GridCoords)
        {
            Vector3 worldPosition = nodes[0, 0] + GridCoords.x * Vector3.right + GridCoords.z * Vector3.forward +
                                    Constants.HeightCoefficient * GridCoords.y * Vector3.up;
            return worldPosition;
        }

        public void Move(Transform creatureTransform, Vector3Int direction)
        {
            Vector3 currentPosition = creatureTransform.position;

            Assert.IsTrue(-1 <= direction.x && direction.x <= 1);
            Assert.IsTrue(-1 <= direction.y && direction.y <= 1);
            Assert.IsTrue(-1 <= direction.z && direction.z <= 1);
            Assert.IsTrue(direction.magnitude > 0);

            Vector3Int oldCoords = WorldPositionToGridCoords(currentPosition);
            Vector3Int newCoords = oldCoords + direction;
        
            Assert.IsTrue(0 <= newCoords.x && newCoords.x < nodes.GetLength(0));
            Assert.IsTrue(0 <= newCoords.y && newCoords.y < nodes.GetLength(1));
        
            Vector3 newPosition = nodes[newCoords.x, newCoords.y];
            creatureTransform.Translate(newPosition - currentPosition);
        }
    
    }
}
