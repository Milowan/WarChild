using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseManager : MissionManager
{
    public Character defensePoint;
    private float waveCooldown;
    private float cooldownTimer;
    private int wave;
    private int addPerWave;

    // Start is called before the first frame update
    void Start()
    {
        waveCooldown = 5f;
        cooldownTimer = 0f;
        AIManager.StartWithTarget(defensePoint);
        wave = 0;
        AIManager.maxSpawn = 20;
        AIManager.canSpawn = false;
        addPerWave = 5;
        StartWave();
    }

    private void FixedUpdate()
    {
        PlayerHUD.objective.text = "Defend the Objective, wave : " + wave;
        if(!AIManager.canSpawn)
        {
            if (cooldownTimer >= waveCooldown)
            {
                StartWave();
            }
        }
    }

    public void StartWave()
    {
        wave++;
        AIManager.maxSpawn += addPerWave;
        AIManager.canSpawn = true;
        cooldownTimer = 0.0f;
    }
}
