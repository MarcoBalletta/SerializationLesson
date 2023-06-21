using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, ISaveableComponent
{
    public int ammos;

    public void Load()
    {
        ammos = SaveManager.instance.GameData.ammos;   
    }

    public void Save(GameData data)
    {
        data.ammos = ammos;
    }
}
