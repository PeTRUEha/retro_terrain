using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public bool manualControl = true;
    public NavigationGrid navGrid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manualControl)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                navGrid.Move(transform,new Vector2Int(1, 1));
            }
        }

    }
}
