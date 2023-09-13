using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Gold", menuName = "Resources/Gold")]
public class GoldResourceSO : ResourceSO
{
    public float priceIncreasePercentage = 1.0f; // Percentage to increase
    public float priceIncreaseInterval = 5.0f;   // Interval in seconds

    

    // Coroutine to increase the resource amount over time, it keeps running passivly 
    private IEnumerator IncreasePriceOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(priceIncreaseInterval);

            int increaseAmount = Mathf.FloorToInt(price * (priceIncreasePercentage / 100.0f));
            price += increaseAmount;
            Debug.Log($"Increased {itemName} by {increaseAmount}. Total: {quantity}");
        }
    }

    public void Add(int addedAmount)
    {
        quantity += addedAmount;
        Debug.Log($"Added {addedAmount} {itemName}. Total: {quantity}");
    }
}
