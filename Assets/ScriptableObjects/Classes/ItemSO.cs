using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public int id;
    public GameObject prefab;
    public string itemName;
    public Sprite icon;
    public int quantity = 0;

    public int price = 0;
}
