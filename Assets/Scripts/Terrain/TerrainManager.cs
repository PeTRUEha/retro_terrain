using UnityEngine;

namespace Terrain
{
	public class TerrainManager : MonoBehaviour {

		public static TerrainManager instance;
		public int terrainWidth, elementWidth;
		public terrainElement terrainPrefab;
		[HideInInspector]
		public Vector3[,] coords;
		terrainElement[,] terrainElements;
	
		void Awake()
		{ 
			instance = this;
			CreateCoords();
			CreateTerrainElements();

			var navGrid = FindObjectOfType<NavigationGrid>();
			navGrid.Init(this.coords);
		}

		void CreateCoords()
		{
			coords = new Vector3[(terrainWidth + 1), (terrainWidth + 1)];
			/*
        every side needs to be 1 unity longer
        */
			for (int z = 0; z <= terrainWidth; z++)
			{
				//outer loop, z-axis
				for (int x = 0; x <= terrainWidth; x++) 
				{
					/* 
                inner loop, x-axis
                setting height value based on perlin noise
                needs to be optimized low, mid and high frequency noise
                */
					float y = Mathf.PerlinNoise((float)x / 20, (float)z / 20) * 10; // TODO: remove magic constants
					y = Mathf.Floor(y) * Constants.HeightCoefficient;
					coords[x, z] = new Vector3(x, y, z);
				} 
			}

		}

		void CreateTerrainElements()
		{
			//Why not just have a single big chunk instead of multiple terrain elements?
			int elementsPerSide = terrainWidth / elementWidth;
			terrainElements = new terrainElement[elementsPerSide, elementsPerSide];

			for (int z = 0; z < elementsPerSide; z++)
			{
				//outer loop, z-axis
				for (int x = 0; x < elementsPerSide; x++)
				{

					terrainElement elementInstance = Instantiate(terrainPrefab, this.transform);
					elementInstance.Initialize(x, z);
					terrainElements[x, z] = elementInstance;
				}
			}
		}
	
	}
}
