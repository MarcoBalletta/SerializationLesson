using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, ISaveableComponent
{
    public int ammos;

    public void Load(GameData data)
    {
        if(data is PlayerData)
            ammos = (data as PlayerData).ammos;   
    }

    public void Save(GameData data)
    {
        if(data is PlayerData)
            ((PlayerData)data).ammos = ammos;
    }
}
