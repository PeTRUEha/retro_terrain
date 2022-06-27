using UnityEngine;
using Terrain;

namespace Creature
{
    public class AnimalController: MonoBehaviour
    {
        private Animal _animal;
        private NavigationGrid _navGrid;

        AnimalController()
        {
            _animal = gameObject.GetComponent<Animal>();
            _navGrid = GameObject.Find("NavigationGrid").GetComponent<NavigationGrid>();
        }

    }
}