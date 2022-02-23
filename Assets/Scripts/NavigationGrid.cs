using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UIElements;

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

    Vector2Int GridCoordsByWorldPosition(Vector3 worldPosition)
    {
        Vector3 gridCoords = worldPosition - nodes[0, 0];
        var x = (int) gridCoords.x;
        var y = (int) gridCoords.z;
        return new Vector2Int(x, y);
    }

    public void Move(Transform creatureTransform, Vector2Int direction)
    {
        Vector3 currentPosition = creatureTransform.position;

        Assert.IsTrue(-1 <= direction.x && direction.x <= 1);
        Assert.IsTrue(-1 <= direction.y && direction.y <= 1);
        Assert.IsTrue(direction.magnitude > 0);

        Vector2Int oldCoords = GridCoordsByWorldPosition(currentPosition);
        Vector2Int newCoords = oldCoords + direction;
        
        Assert.IsTrue(0 <= newCoords.x && newCoords.x < nodes.GetLength(0));
        Assert.IsTrue(0 <= newCoords.y && newCoords.y < nodes.GetLength(1));
        
        Vector3 newPosition = nodes[newCoords.x, newCoords.y];
        creatureTransform.Translate(newPosition - currentPosition);
    }
    
}
