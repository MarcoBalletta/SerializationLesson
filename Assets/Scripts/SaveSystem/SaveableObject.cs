using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveableObject : MonoBehaviour, ISaveable
{

    private ISaveableComponent[] saveableComponents;

    // Start is called before the first frame update
    void Awake()
    {
        saveableComponents = GetComponentsInChildren<ISaveableComponent>();
    }

    private void OnEnable()
    {
        SaveManager.instance.SubscriveSaveableObject(this);
    }

    private void OnDisable()
    {
        SaveManager.instance.UnsubscriveSaveableObject(this);
    }

    public void SaveAll(GameData data)
    {
        foreach(var component in saveableComponents)
        {
            component.Save(data);
        }
    }

    public void LoadAll()
    {
        foreach (var component in saveableComponents)
        {
            component.Load();
        }
    }
}
