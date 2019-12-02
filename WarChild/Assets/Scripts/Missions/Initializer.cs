using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MissionData.Load();
        if (MissionData.missions.Count == 0)
        {
            GenerateMissions();
        }
        SceneManager.LoadScene("MainMenu");
    }

    private void GenerateMissions()
    {
        MissionData.AddToList(new Mission("Defense", true));
        MissionData.AddToList(new Mission("Exterminate", false, MissionData.missions[0]));
    }
}
