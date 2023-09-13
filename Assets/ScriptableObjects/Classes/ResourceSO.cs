using System.Collections;
using UnityEngine;
public class ResourceSO : ItemSO
{
    public void Use(int usedAmount)
    {
        quantity -= usedAmount;
        //Debug.Log($"Used {usedAmount} {itemName}. Remaining: {quantity}");
    }

    public IEnumerator IncrementWithDelay(int valueToAdd, float delay)
    {
        yield return new WaitForSeconds(delay);

        quantity += valueToAdd;
        //Debug.Log($"Added {valueToAdd} {itemName}. Total: {quantity}");
    }


    public int GetQuantity()
    {
        return quantity;
    }

    public void SetQuantity(int quantity)
    {
        this.quantity = quantity;
    }
}
