using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string directory = "Savings";
    private const string fileName = "saveData.txt";

    public static SaveManager instance;
    private GameData gameData;
    private FileDataHandler dataHandler;
    public PlayerMovement movement;
    private List<ISaveable> saveableObjects = new List<ISaveable>();

    public GameData GameData { get => gameData; set => gameData = value; }

    private void Awake()
    {
        instance = this;
        dataHandler = new FileDataHandler(directory, fileName);
        movement = FindObjectOfType<PlayerMovement>();
    }

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        gameData = dataHandler.ReadFromFile();
        if (gameData == null) NewGame();

        foreach (var saveable in saveableObjects)
        {
            saveable.LoadAll();
        }
    }

    private void NewGame()
    {
        gameData = new GameData();
    }

    public void Save()
    {
        foreach(var saveable in saveableObjects)
        {
            saveable.SaveAll(gameData);
        }
        dataHandler.WriteInFile(gameData);
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
}
