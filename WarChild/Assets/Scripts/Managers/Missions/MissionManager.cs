using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    private void Awake()
    {
        MissionTracker.SetCurrentMission(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void Extract()
    {

    }
}
