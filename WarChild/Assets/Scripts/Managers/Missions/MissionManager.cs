using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Awake()
    {
        MissionTracker.SetCurrentMission(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(playerPrefab).transform.position = GameObject.Find("PlayerSpawn").transform.position;
    }

    protected virtual void Extract()
    {

    }
}
