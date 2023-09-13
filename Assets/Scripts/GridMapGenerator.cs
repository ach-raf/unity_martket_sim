using UnityEngine;
using System.Collections.Generic;

public class GridMapGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
<<<<<<< HEAD
    public BuildingDataSO[] buildingsData; // An array of building scriptable objects

    public int gridSizeX = 20;
    public int gridSizeY = 20;
    public float cellSize = 5.0f;

=======
    public GameObject[] buildingPrefabs; // An array of building prefabs

    public int gridSizeX = 20;
    public int gridSizeY = 20;
    public float spacing = 1.0f;
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04

    private Tile[,] tiles;
    private Building[,] buildings;

<<<<<<< HEAD
    private void OnEnable()
    {
        EventManager.TileClicked += HandleTileClicked;
    }

    private void OnDisable()
    {
        EventManager.TileClicked -= HandleTileClicked;
    }

=======
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    private void Start()
    {
        GenerateGridMap();
        MoveCameraToStartPosition();
<<<<<<< HEAD
=======
        PlaceBuildings();
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    }

    private void GenerateGridMap()
    {
        tiles = new Tile[gridSizeX, gridSizeY];
        buildings = new Building[gridSizeX, gridSizeY];

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
<<<<<<< HEAD
                Vector3 spawnPosition = new Vector3(x * cellSize, 0, y * cellSize); // Adjusted for 3D
                GameObject tileGameObject = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
                tileGameObject.transform.SetParent(transform);
=======
                Vector3 spawnPosition = new(x * spacing, y * spacing, 0);
                GameObject tileGameObject = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
                Tile tile = tileGameObject.GetComponent<Tile>();
                tile.SetTileGameObject(tileGameObject);
                //tile.ChangeToRandomColor();
                tile.GetTileGameObject().name = $"Tile ({x}, {y})";
                tile.SetXY(x, y);
                tiles[x, y] = tile;
            }
        }
    }

<<<<<<< HEAD
    public Vector2Int WorldToGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / cellSize);
        int y = Mathf.FloorToInt(worldPosition.z / cellSize);
        return new Vector2Int(x, y);
    }
=======
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    // Example function to manipulate a tile's position
    public void MoveTile(int x, int y, Vector3 newPosition)
    {
        if (IsValidPosition(x, y))
        {
            tiles[x, y].GetTileGameObject().transform.position = newPosition;
        }
    }

    private bool IsValidPosition(int x, int y)
    {
<<<<<<< HEAD
        if (x < 0 || x >= gridSizeX  || y < 0 || y >= gridSizeY)
=======
        if (x < 0 || x >= gridSizeX || y < 0 || y >= gridSizeY)
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
        {
            return false; // Outside the grid boundaries
        }

        if (tiles[x, y].IsOccupied())
        {
            return false; // Tile is already occupied
        }

        return true;
    }
    private bool IsValidBuildingPlacement(int startX, int startY, int width, int height)
    {
        for (int x = startX; x < startX + width; x++)
        {
            for (int y = startY; y < startY + height; y++)
            {
                if (x < 0 || x >= gridSizeX || y < 0 || y >= gridSizeY || tiles[x, y].IsOccupied())
                {
                    return false;
                }
            }
        }
        return true;
    }



    private void MoveCameraToStartPosition()
    {
        Vector3 gridCenter = CalculateGridCenter();
        Camera.main.transform.position = new Vector3(gridCenter.x, gridCenter.y, Camera.main.transform.position.z);
    }

    private Vector3 CalculateGridCenter()
    {
<<<<<<< HEAD
        float gridWidth = gridSizeX * cellSize;
        float gridHeight = gridSizeY * cellSize;
=======
        float gridWidth = gridSizeX * spacing;
        float gridHeight = gridSizeY * spacing;
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04

        float centerX = gridWidth * 0.5f;
        float centerY = gridHeight * 0.5f;

        return new Vector3(centerX, centerY, 0);
    }
<<<<<<< HEAD

    private void PlaceBuilding(int startX, int startY, int width, int height, GameObject buildingPrefab)
    {
        float offsetX = 0;
        Debug.Log(offsetX);
        float offsetY = 0;
        // Adjust pivot offset for bottom left corner
        Vector3 pivotOffset = new Vector3(1.5f, 0, -1.5f); // Bottom left pivot offset
=======
    private void PlaceBuildings()
    {
        List<Vector2Int> availableLocations = new List<Vector2Int>();

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                if (!tiles[x, y].IsOccupied())
                {
                    availableLocations.Add(new Vector2Int(x, y));
                }
            }
        }

        int buildingsToPlace = Mathf.Min(10, availableLocations.Count);

        for (int i = 0; i < buildingsToPlace; i++)
        {
            int prefabIndex = Random.Range(0, buildingPrefabs.Length);
            GameObject buildingPrefab = buildingPrefabs[prefabIndex];

            Vector2Int location = availableLocations[Random.Range(0, availableLocations.Count)];
            availableLocations.Remove(location);

            int width = Random.Range(1, 4);
            int height = Random.Range(1, 4);

            if (IsValidBuildingPlacement(location.x, location.y, width, height))
            {
                buildingPrefab.transform.localScale = new Vector3(width, height, 1);
                PlaceBuilding(location.x, location.y, width, height, buildingPrefab);
            }
        }
    }



    private void PlaceBuilding(int startX, int startY, int width, int height, GameObject buildingPrefab)
    {
        float offsetX = (width - 1) * 0.5f * spacing;
        float offsetY = (height - 1) * 0.5f * spacing;
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
        for (int x = startX; x < startX + width; x++)
        {
            for (int y = startY; y < startY + height; y++)
            {
<<<<<<< HEAD
                if (IsValidBuildingPlacement(x, y, width, height))
                {
                    
                    
                    Vector3 spawnPosition = new Vector3((x + offsetX) * cellSize, 1, (y + offsetY) * cellSize) ;
                    //spawnPosition += pivotOffset * cellSize; // Apply pivot offset


                    GameObject buildingGameObject = Instantiate(buildingPrefab, spawnPosition, Quaternion.identity);
                    buildingGameObject.name = $"Building ({x}, {y}), {width}x{height}";
                    //buildingGameObject.transform.localScale = new Vector3(width,1, height);
                    Building building = buildingGameObject.GetComponent<Building>();
                    building.SetBuildingGameObject(buildingGameObject);
                    Debug.Log(building.GetBuildingGameObject().name);
=======
                if (IsValidPosition(x, y))
                {
                    //Vector3 spawnPosition = new Vector3(x * spacing, y * spacing, 0);
                    //Vector3 spawnPosition = new Vector3(x * spacing - offsetX, y * spacing - offsetY, 0);
                    Vector3 spawnPosition = new Vector3((x + offsetX) * spacing, (y + offsetY) * spacing, 0);
                    Vector3 pivotOffset = new Vector3(0.5f, 0.5f, 0); // Center pivot offset

                    

                    GameObject buildingGameObject = Instantiate(buildingPrefab, spawnPosition, Quaternion.identity);
                    Building building = buildingGameObject.GetComponent<Building>();
                    building.SetBuildingGameObject(buildingGameObject);
                    building.GetBuildingGameObject().name = $"Building ({x}, {y}), {width}x{height}";
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
                    building.Initialize(width, height);
                    buildings[x, y] = building;

                    // Mark the tiles as occupied by the building
                    for (int bx = x; bx < x + width; bx++)
                    {
                        for (int by = y; by < y + height; by++)
                        {
                            tiles[bx, by].SetIsOccupied(true);
<<<<<<< HEAD
                            tiles[bx, by].ChangeMaterial();
=======
                            tiles[bx, by].ChangeColor(Color.black);
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
                        }
                    }
                }
            }
        }
    }

<<<<<<< HEAD
    private void HandleTileClicked(Tile tile)
    {
        Vector2Int gridPosition = tile.GetXY();
        Debug.Log($"Tile ({gridPosition.x}, {gridPosition.y}) was clicked!");
        // Move the tile to a random position
        //MoveTile(gridPosition.x, gridPosition.y, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)));
        // Place a building on the tile
        // random width and height between 1 and 5
        BuildingDataSO buildingData = buildingsData[Random.Range(0, buildingsData.Length)];
        PlaceBuilding(gridPosition.x, gridPosition.y, buildingData.width, buildingData.height, buildingData.buildingGameObject);
    }



=======
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
}
