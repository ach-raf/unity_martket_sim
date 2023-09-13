using System;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class EventManager{
    public static event Action<Building> BuildingRightClicked;
    public static void OnBuildingRightClicked(Building building) => BuildingRightClicked?.Invoke(building);
<<<<<<< HEAD

    // on tile clicked
    public static event Action<Tile> TileClicked;
    public static void OnTileClicked(Tile tile) => TileClicked?.Invoke(tile);

=======
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
}
