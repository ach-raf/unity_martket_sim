using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IClickable
{
    public BuildingDataSO buildingData; // The ScriptableObject containing the building data.
    public List<RecipeResourceSO> craftingRecipes = new(); // List of available crafting recipes.
    

    private void Awake()
    {
        //create a new instance of the buildingData scriptable object
        buildingData = ScriptableObject.CreateInstance<BuildingDataSO>();
        
    }

    public void Initialize(int width, int height)
    {
        buildingData.width = width;
        buildingData.height = height;
    }

    public void OnClick()
    {
        Debug.Log(buildingData.buildingGameObject.name + " was clicked!");
        foreach (RecipeResourceSO recipe in craftingRecipes)
        {
            Craft(recipe);
        }

        // Implement the specific behavior you want when the tile is clicked.
    }

    public void OnRightClick()
    {
        Debug.Log(buildingData.buildingGameObject.name + " was right clicked!");
        // Implement the specific behavior you want when the tile is right clicked.
    }

    public void Place(Vector3 position)
    {
        transform.position = position;
    }

    public int GetWidth()
    {
        return buildingData.width;
    }

    public int GetHeight()
    {
        return buildingData.height;
    }

    public void SetBuildingGameObject(GameObject buildingGameObject)
    {
        this.buildingData.buildingGameObject = buildingGameObject;
    }

    public GameObject GetBuildingGameObject()
    {
        return buildingData.buildingGameObject;
    }

    // Add a method to process crafting based on a recipe.
    public void Craft(RecipeResourceSO recipe)
    {
        // create a new instance of the produced resource scriptable object with ScriptableObject.CreateInstance<ResourceSO>(), and add it to the inventory
        // get the resource from the inventory
        // check if the recipe can be crafted based on available resources
        // if so, produce the item
        // if not, log that there are not enough resources
        ResourceSO producedResource = Object.Instantiate(recipe.producedResource);
        buildingData.inventory.AddItem(producedResource);


        
        // Check if the recipe can be crafted based on available resources.
        if (recipe.resourceRequirements.Count == 0)
        {
            // Produce the item.
            Debug.Log("Crafting " + producedResource.itemName);
            StartCoroutine(producedResource.IncrementWithDelay(1, 2f)); // Adjust the delay and amount as needed
        }
        else
        {
            foreach (ResourceRequirement requirement in recipe.resourceRequirements)
            {
                if (requirement.resource.GetQuantity() < requirement.quantity)
                {
                    Debug.Log("Not enough resources to craft the item.");
                    break;
                }
                requirement.resource.Use(requirement.quantity);
                // Produce the item.
                Debug.Log("Crafting " + producedResource.itemName);
                StartCoroutine(producedResource.IncrementWithDelay(1, 2f)); // Adjust the delay and amount as needed
            }
        }

        Debug.Log(producedResource.itemName + " " + producedResource.GetQuantity());
        
    }

    



}
