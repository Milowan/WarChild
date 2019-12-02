using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(playerPrefab).transform.position = GameObject.Find("PlayerSpawn").transform.position;
    }

    protected virtual void Extract()
    {

    }
}
