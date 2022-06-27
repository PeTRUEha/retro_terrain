using UnityEngine;
using Terrain;

namespace Creature
{
    public class Creature: MonoBehaviour
    {
        public Vector3Int coords;
        public Vector2Int FlatCoords
        {
            get => new(coords.x, coords.z);
            set => coords = new Vector3Int(value.x, navGrid.GetGridHeight(value), value.y);
        } 

        protected NavigationGrid navGrid;
        // add init of coords
        void Start()
        {
            {
                navGrid = GameObject.Find("NavigationGrid").GetComponent<NavigationGrid>();
                coords = navGrid.WorldPositionToGridCoords(transform.position);
            }
        }
    }
}
