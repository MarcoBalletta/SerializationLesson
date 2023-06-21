
using System.IO;
using UnityEngine;

public class FileDataHandler
{
    private string directory;
    private string fileName;

    public FileDataHandler(string directory, string fileName)
    {
        this.directory = directory;
        this.fileName = fileName;
    }

    public void WriteInFile(GameData data)
    {
        string dir = Path.Combine(Application.dataPath, directory);
        Debug.Log("Directory = " + dir);
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string fullPath = Path.Combine(dir, fileName);
        string json = JsonUtility.ToJson(data);

        using (FileStream stream = new FileStream(fullPath, FileMode.OpenOrCreate))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(json);
            }
        }
    }

    public GameData ReadFromFile()
    {
        GameData data = null;
        string fullPath = Path.Combine(Application.dataPath,directory, fileName);

        if (File.Exists(fullPath))
        {
            string dataString = null;
            using (FileStream stream = new FileStream(fullPath, FileMode.Open))
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    dataString = reader.ReadToEnd();
                }
            }
            data = JsonUtility.FromJson<GameData>(dataString);
        }
        else
        {
            Debug.Log("Save file not found");
        }
        return data;
    }
}
