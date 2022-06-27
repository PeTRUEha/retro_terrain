using Terrain;
using UnityEngine;

namespace Creature
{
    public class Animal : Creature
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
                    navGrid.Move(transform,new Vector3Int(1, 1, 1));
                }
            }

        }
    }
}
