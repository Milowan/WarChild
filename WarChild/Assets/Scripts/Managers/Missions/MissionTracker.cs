using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionTracker 
{
    public static string currentMission;

    public static void SetCurrentMission(string mission)
    {
        currentMission = mission;
    }
}
