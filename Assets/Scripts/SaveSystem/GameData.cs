using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public int ammos;

    public GameData()
    {
        name = "player";
        position = new Vector3(0, 1, 0);
        rotation = Quaternion.identity;
        ammos = 0;
    }
}
