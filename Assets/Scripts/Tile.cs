using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IClickable
{
    public Material occupiedMaterial;
    private GameObject tileGameObject;
    private Renderer objectRenderer;
    private bool isOccupied = false;
    private int x;
    private int y;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            objectRenderer = GetComponentInChildren<Renderer>();
        }
        
    }
    
    public void OnClick()
    {
        //Debug.Log(tileGameObject.name + " was clicked!");
        
        EventManager.OnTileClicked(this);
    }

    public void OnRightClick()
    {
        Debug.Log(tileGameObject.name + " was right clicked!");
        // Implement the specific behavior you want when the tile is right clicked.
    }

    public void ChangeMaterial()
    {
        objectRenderer.material = occupiedMaterial;
    }

    public void ChangeToRandomColor()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        //ChangeColor(new Color(r, g, b));
    }

    public void SetTileGameObject(GameObject tileGameObject)
    {
        this.tileGameObject = tileGameObject;
    }

    public GameObject GetTileGameObject()
    {
        return tileGameObject;
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetIsOccupied(bool isOccupied)
    {
        this.isOccupied = isOccupied;
    }

    public void SetXY(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2Int GetXY()
    {
        return new Vector2Int(x, y);
    }

}
