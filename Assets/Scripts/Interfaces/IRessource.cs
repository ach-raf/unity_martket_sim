using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRessource {
    int GetRessource();
    void SetRessource(int value);
    void AddRessource(int value);
    void RemoveRessource(int value);

    
}

