using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseManager : MissionManager
{
    public GameObject extractionPrefab;
    public Character defensePoint;
    public AIManager aIManager;
    private float waveCooldown;
    private float cooldownTimer;
    private int wave;
    private int addPerWave;
    public static bool waveOver;
    private float spawnCooldown;
    private float spawnCooldownTimer;
    private int maxSpawn;
    private int spawnCount;
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        waveCooldown = 5f;
        cooldownTimer = 0f;
        spawnCooldown = 3f;
        spawnCooldownTimer = spawnCooldown;
        aIManager.StartWithTarget(defensePoint);
        wave = 0;
        maxSpawn = 5;
        canSpawn = false;
        addPerWave = 5;
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(1);
        StartWave();
    }

    private void FixedUpdate()
    {
        PlayerHUD.objective.text = "Defend the Objective, wave : " + wave;
        if(!canSpawn)
        {
            if (waveOver)
            {
                if (cooldownTimer >= waveCooldown)
                {
                    StartWave();
                }
                else
                {
                    cooldownTimer += Time.deltaTime;
                }
                if (wave % 5 == 0)
                    Extract();
            }
        }
        else
        {
            if (cooldownTimer >= spawnCooldown)
            {
                Enemy enemy = aIManager.GetInactiveEnemy();
                if (enemy != null)
                {
                    Transform[] spawnPoints = aIManager.GetSpawnPoints();
                    enemy.Initialize(spawnPoints[Random.Range(0, spawnPoints.Length - 1)]);
                    enemy.Spawn();
                    if (spawnCount == maxSpawn - 1)
                        enemy.IsLast();
                }
                cooldownTimer = 0.0f;
                ++spawnCount;
                if (spawnCount >= maxSpawn)
                    canSpawn = false;
            }

            cooldownTimer += Time.deltaTime;
        }
    }

    public void StartWave()
    {
        wave++;
        maxSpawn += addPerWave;
        canSpawn = true;
        cooldownTimer = 0.0f;
    }

    protected override void Extract()
    {
        GameEventManager.TriggerPause();
        UIManager.OpenExMenu();
    }
}
