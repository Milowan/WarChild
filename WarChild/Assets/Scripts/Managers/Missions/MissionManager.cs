using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public static string currentMission;

    private void Awake()
    {
        currentMission = SceneManager.GetActiveScene().name;
    }
}
