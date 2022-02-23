using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationGrid : MonoBehaviour
{
    private Vector3[,] nodes;
    private bool initialized = false;

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
}
