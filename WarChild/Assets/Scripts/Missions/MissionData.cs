using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MissionData
{
    public static List<Mission> missions;

    public static void AddToList(Mission mission)
    {
        if (missions == null)
            missions = new List<Mission>();

        missions.Add(mission);
    }

    public static void Save()
    {
        if (missions == null)
            missions = new List<Mission>();

        FileStream stream = File.Create(Application.persistentDataPath + "/gamesave.save");
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, missions);
        stream.Close();
    }

    public static void Load()
    {
        if (missions == null)
            missions = new List<Mission>();

        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            FileStream stream = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            missions = (List<Mission>)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
