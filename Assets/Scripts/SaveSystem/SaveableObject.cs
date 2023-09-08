using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableObject<T> : MonoBehaviour, ISaveable where T : GameData, new()
{

    private ISaveableComponent[] saveableComponents;
    [SerializeField] private string fileName;
    protected T gameData = new T();

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

    public ReturnedSaveableData SaveAll()
    {
        ReturnedSaveableData saveableDataTemp = new ReturnedSaveableData();
        saveableDataTemp.fileName = fileName;
        gameData = new T();
        foreach(var component in saveableComponents)
        {
            component.Save(gameData);
        }
        saveableDataTemp.data = gameData;
        return saveableDataTemp;
    }

    public void LoadAll()
    {
        SaveManager.instance.LoadFromFileInto(out gameData, fileName);
        if (gameData == null) return;
        foreach (var component in saveableComponents)
        {
            component.Load(gameData);
        }
    }
}
