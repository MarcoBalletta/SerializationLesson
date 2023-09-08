using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string directory = "Savings";
    private const string fileName = "saveData.txt";

    public static SaveManager instance;
    //private GameData gameData;
    private FileDataHandler dataHandler;
    private List<ISaveable> saveableObjects = new List<ISaveable>();

    private void Awake()
    {
        instance = this;
        dataHandler = new FileDataHandler(directory);
    }

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        foreach (var saveable in saveableObjects)
        {
            saveable.LoadAll();
        }
    }

    private void NewGame()
    {
        
    }

    public void Save()
    {
        foreach(var saveable in saveableObjects)
        {
            dataHandler.WriteInFile(saveable.SaveAll());
        }
    }

    public void SubscriveSaveableObject(ISaveable saveable)
    {
        if (!saveableObjects.Contains(saveable))
        {
            saveableObjects.Add(saveable);
        }
    }

    public void UnsubscriveSaveableObject(ISaveable saveable)
    {
        if (!saveableObjects.Contains(saveable))
        {
            saveableObjects.Remove(saveable);
        }
    }

    public void LoadFromFileInto<T>(out T data, string fileName) where T: GameData
    {
        data = dataHandler.ReadFromFile<T>(fileName);
    }
}
