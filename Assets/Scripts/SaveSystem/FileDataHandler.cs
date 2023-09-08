
using System.IO;
using UnityEngine;

public class FileDataHandler
{
    private string directory;

    public FileDataHandler(string directory)
    {
        this.directory = directory;
    }

    public void WriteInFile(ReturnedSaveableData returnedData)
    {
        string dir = Path.Combine(Application.dataPath, directory);
        
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string fullPath = Path.Combine(dir, returnedData.fileName);
        string json = JsonUtility.ToJson(returnedData.data);

        using (FileStream stream = new FileStream(fullPath, FileMode.OpenOrCreate))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(json);
            }
        }
    }

    public T ReadFromFile<T>(string fileName) where T: GameData
    {
        T data = null;
        string fullPath = Path.Combine(Application.dataPath, directory, fileName);

        if (File.Exists(fullPath))
        {
            string dataString = null;
            using (FileStream stream = new FileStream(fullPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataString = reader.ReadToEnd();
                }
            }
            data = JsonUtility.FromJson<T>(dataString);
        }
        else
        {
            Debug.Log("Save file not found");
        }
        return data;
    }
}
