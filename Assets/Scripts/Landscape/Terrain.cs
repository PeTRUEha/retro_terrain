using UnityEngine;

namespace Landscape
{
    public class Terrain : MonoBehaviour
    {
        public int x_dim;
        public int z_dim;
        public Vector3[,] nodes;

        public bool initialized = false;  // TODO: remove it?

        public void Init(Vector3[,] coords){
            nodes = new Vector3[coords.GetLength(0), coords.GetLength(1)];
            for (int x = 0; x < coords.GetLength(0) - 1; x++){
                for (int z = 0; z < coords.GetLength(1) - 1; z++){
                    nodes[x, z] = (coords[x, z] + coords[x + 1, z] + coords[x, z + 1] + coords[x + 1, z + 1]) / 4;
                }
            }

            x_dim = nodes.GetLength(0);
            z_dim = nodes.GetLength(1);
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
        public Vector3Int WorldToMap(Vector3 worldPosition)
        {
            Vector3 floatGridCoords = worldPosition - nodes[0, 0];
            var x = Mathf.RoundToInt(floatGridCoords.x);
            var y = Mathf.RoundToInt(floatGridCoords.y / Constants.HeightCoefficient);
            var z = Mathf.RoundToInt(floatGridCoords.z);
            return new Vector3Int(x, y, z);
        }
        public Vector3 MapToWorld(Vector2Int gridCoords)
        {
//            Vector3 worldPosition = nodes[0, 0] + gridCoords.x * Vector3.right + gridCoords.z * Vector3.forward +
//                                    Constants.HeightCoefficient * gridCoords.y * Vector3.up;
            return MapToWorld(gridCoords.x, gridCoords.y);
        }
        
        public Vector3 MapToWorld(int x, int y)
        {
            return nodes[x, y];
        }

        public int GetGridHeight(Vector2Int gridCoords)
        {
            return WorldToMap(nodes[gridCoords.x, gridCoords.y]).y;
        }
    }
}
