using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe Resource", menuName = "ScriptableObjects/RecipeResource")]
public class RecipeResourceSO : ItemSO
{
    [Header("Recipe")]
    public ResourceSO producedResource; // The resource that is produced by this recipe.
    public List<ResourceRequirement> resourceRequirements = new List<ResourceRequirement>(); // List of required resources and their quantities.
}

[System.Serializable]
public class ResourceRequirement
{
    public ResourceSO resource; // The required resource.
    public int quantity; // The quantity of the required resource.
}
