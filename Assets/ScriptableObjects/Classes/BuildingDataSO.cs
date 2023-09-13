using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Custom/Building Data", order = 1)]
public class BuildingDataSO : ScriptableObject
{
    public GameObject buildingGameObject; // The GameObject representing the building
    public int width;               // Width of the building
    public int height;              // Height of the building

    public int x;
    public int y;

    public Inventory inventory = new();
    
}
