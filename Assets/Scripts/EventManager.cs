using System;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class EventManager{
    public static event Action<Building> BuildingRightClicked;
    public static void OnBuildingRightClicked(Building building) => BuildingRightClicked?.Invoke(building);

    // on tile clicked
    public static event Action<Tile> TileClicked;
    public static void OnTileClicked(Tile tile) => TileClicked?.Invoke(tile);

}
