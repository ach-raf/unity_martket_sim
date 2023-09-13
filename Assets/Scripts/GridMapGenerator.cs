using UnityEngine;
using System.Collections.Generic;

public class GridMapGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    public BuildingDataSO[] buildingsData; // An array of building scriptable objects

    public int gridSizeX = 20;
    public int gridSizeY = 20;
    public float cellSize = 5.0f;


    private Tile[,] tiles;
    private Building[,] buildings;

    private void OnEnable()
    {
        EventManager.TileClicked += HandleTileClicked;
    }

    private void OnDisable()
    {
        EventManager.TileClicked -= HandleTileClicked;
    }

    private void Start()
    {
        GenerateGridMap();
        MoveCameraToStartPosition();
    }

    private void GenerateGridMap()
    {
        tiles = new Tile[gridSizeX, gridSizeY];
        buildings = new Building[gridSizeX, gridSizeY];

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 spawnPosition = new Vector3(x * cellSize, 0, y * cellSize); // Adjusted for 3D
                GameObject tileGameObject = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
                tileGameObject.transform.SetParent(transform);
                Tile tile = tileGameObject.GetComponent<Tile>();
                tile.SetTileGameObject(tileGameObject);
                //tile.ChangeToRandomColor();
                tile.GetTileGameObject().name = $"Tile ({x}, {y})";
                tile.SetXY(x, y);
                tiles[x, y] = tile;
            }
        }
    }

    public Vector2Int WorldToGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / cellSize);
        int y = Mathf.FloorToInt(worldPosition.z / cellSize);
        return new Vector2Int(x, y);
    }
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
        if (x < 0 || x >= gridSizeX  || y < 0 || y >= gridSizeY)
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
        float gridWidth = gridSizeX * cellSize;
        float gridHeight = gridSizeY * cellSize;

        float centerX = gridWidth * 0.5f;
        float centerY = gridHeight * 0.5f;

        return new Vector3(centerX, centerY, 0);
    }

    private void PlaceBuilding(int startX, int startY, int width, int height, GameObject buildingPrefab)
    {
        float offsetX = 0;
        Debug.Log(offsetX);
        float offsetY = 0;
        // Adjust pivot offset for bottom left corner
        Vector3 pivotOffset = new Vector3(1.5f, 0, -1.5f); // Bottom left pivot offset
        for (int x = startX; x < startX + width; x++)
        {
            for (int y = startY; y < startY + height; y++)
            {
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
                    building.Initialize(width, height);
                    buildings[x, y] = building;

                    // Mark the tiles as occupied by the building
                    for (int bx = x; bx < x + width; bx++)
                    {
                        for (int by = y; by < y + height; by++)
                        {
                            tiles[bx, by].SetIsOccupied(true);
                            tiles[bx, by].ChangeMaterial();
                        }
                    }
                }
            }
        }
    }

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



}
