using System.IO;
using UnityEngine;

/*
 * FileManager class is responsible for handling file operations such as 
 * saving and loading game data to and from a file. It uses JSON format 
 * for serialization and deserialization of game data.
 */
public static class FileManager
{
    private static string filePath = Application.persistentDataPath + "/gameData.json";

    // Saves the given game data to a file in JSON format.
    public static void SaveData(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    // Loads game data from a file. If no file exists, returns a new GameData instance.
    public static GameData LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            return new GameData(); // Return a new GameData instance if no file exists
        }
    }
}
