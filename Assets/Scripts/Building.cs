<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
using UnityEngine;

public class Building : MonoBehaviour, IClickable
{
<<<<<<< HEAD
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
=======
    private GameObject buildingGameObject;
    private int x;
    private int y;
    private int width;
    private int height;

    public void Initialize(int width, int height)
    {
        this.width = width;
        this.height = height;
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    }

    public void OnClick()
    {
<<<<<<< HEAD
        Debug.Log(buildingData.buildingGameObject.name + " was clicked!");
        foreach (RecipeResourceSO recipe in craftingRecipes)
        {
            Craft(recipe);
        }
=======
        Debug.Log(buildingGameObject.name + " was clicked!");
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04

        // Implement the specific behavior you want when the tile is clicked.
    }

    public void OnRightClick()
    {
<<<<<<< HEAD
        Debug.Log(buildingData.buildingGameObject.name + " was right clicked!");
=======
        Debug.Log(buildingGameObject.name + " was right clicked!");
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
        // Implement the specific behavior you want when the tile is right clicked.
    }

    public void Place(Vector3 position)
    {
        transform.position = position;
    }

    public int GetWidth()
    {
<<<<<<< HEAD
        return buildingData.width;
=======
        return width;
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    }

    public int GetHeight()
    {
<<<<<<< HEAD
        return buildingData.height;
=======
        return height;
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    }

    public void SetBuildingGameObject(GameObject buildingGameObject)
    {
<<<<<<< HEAD
        this.buildingData.buildingGameObject = buildingGameObject;
=======
        this.buildingGameObject = buildingGameObject;
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    }

    public GameObject GetBuildingGameObject()
    {
<<<<<<< HEAD
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

    



=======
        return buildingGameObject;
    }
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
}
