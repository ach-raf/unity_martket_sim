using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<ItemSO> items;

    public Inventory()
    {
        items = new List<ItemSO>();
    }
    public List<ItemSO> GetItems()
    {
        return items;
    }
    public void AddItem(ItemSO item)
    {
        items.Add(item);
    }
    public void RemoveItem(ItemSO item)
    {
        items.Remove(item);
    }
    public void RemoveItem(int index)
    {
        items.RemoveAt(index);
    }
    public void RemoveAllItems()
    {
        items.Clear();
    }
    public int GetItemCount()
    {
        return items.Count;
    }
    public ItemSO GetItem(int index)
    {
        return items[index];
    }
    public ItemSO GetItem(string name)
    {
        foreach (ItemSO item in items)
        {
            if (item.name == name)
            {
                return item;
            }
        }
        return null;
    }
    public ItemSO GetItem(ItemSO item)
    {
        foreach (ItemSO item_ in items)
        {
            if (item_.name == item.name)
            {
                return item_;
            }
        }
        return null;
    }
    public bool ContainsItem(ItemSO item)
    {
        foreach (ItemSO item_ in items)
        {
            if (item_.name == item.name)
            {
                return true;
            }
        }
        return false;
    }
    public bool ContainsItem(string name)
    {
        foreach (ItemSO item in items)
        {
            if (item.name == name)
            {
                return true;
            }
        }
        return false;
    }
    public bool ContainsItem(int id)
    {
        foreach (ItemSO item in items)
        {
            if (item.id == id)
            {
                return true;
            }
        }
        return false;
    }
    public int GetItemIndex(ItemSO item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == item.name)
            {
                return i;
            }
        }
        return -1;
    }
    public int GetItemIndex(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == name)
            {
                return i;
            }
        }
        return -1;
    }
    public int GetItemIndex(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].id == id)
            {
                return i;
            }
        }
        return -1;
    }
    public int GetItemQuantity(ItemSO item)
    {
        foreach (ItemSO item_ in items)
        {
            if (item_.name == item.name)
            {
                return item_.quantity;
            }
        }
        return 0;
    }
    public int GetItemQuantity(string name)
    {
        foreach (ItemSO item in items)
        {
            if (item.name == name)
            {
                return item.quantity;
            }
        }
        return 0;
    }
    public int GetItemQuantity(int id)
    {
        foreach (ItemSO item in items)
        {
            if (item.id == id)
            {
                return item.quantity;
            }
        }
        return 0;
    }
    public void SetItemQuantity(ItemSO item, int quantity)
    {
        foreach (ItemSO item_ in items)
        {
            if (item_.name == item.name)
            {
                item_.quantity = quantity;
            }
        }
    }
    public void SetItemQuantity(string name, int quantity)
    {
        foreach (ItemSO item in items)
        {
            if (item.name == name)
            {
                item.quantity = quantity;
            }
        }
    }
    public void SetItemQuantity(int id, int quantity)
    {
        foreach (ItemSO item in items)
        {
            if (item.id == id)
            {
                item.quantity = quantity;
            }
        }
    }
    public void AddItemQuantity(ItemSO item, int quantity)
    {
        AddItemQuantity(item.name, quantity);
    }
    public void AddItemQuantity(string name, int quantity)
    {
        foreach (ItemSO item in items)
        {
            if (item.name == name)
            {
                item.quantity += quantity;
            }
        }
    }
    public void AddItemQuantity(int id, int quantity)
    {
        foreach (ItemSO item in items)
        {
            if (item.id == id)
            {
                item.quantity += quantity;
            }
        }
    }
    public void RemoveItemQuantity(ItemSO item, int quantity)
    {
        RemoveItemQuantity(item.name, quantity);
    }
    public void RemoveItemQuantity(string name, int quantity)
    {
        foreach (ItemSO item in items)
        {
            if (item.name == name)
            {
                item.quantity -= quantity;
            }
        }
    }
    public void RemoveItemQuantity(int id, int quantity)
    {
        foreach (ItemSO item in items)
        {
            if (item.id == id)
            {
                item.quantity -= quantity;
            }
        }
    }
    public void RemoveAllItemQuantities()
    {
        foreach (ItemSO item in items)
        {
            item.quantity = 0;
        }
    }
    public void RemoveAllItemQuantities(string name)
    {
        foreach (ItemSO item in items)
        {
            if (item.name == name)
            {
                item.quantity = 0;
            }
        }
    }
    public void RemoveAllItemQuantities(int id)
    {
        foreach (ItemSO item in items)
        {
            if (item.id == id)
            {
                item.quantity = 0;
            }
        }
    }


}

