using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{

    private Enemy[] AIPool;
    private int poolSize;
    public GameObject RiflemanPrefab;
    private float spawnCooldown;
    private float cooldownTimer;
    private Transform[] spawnPoints;
    private static Character initialTarget;
    public static int maxSpawn;
    private int spawnCount;
    public static bool canSpawn;

    private void Awake()
    {
        canSpawn = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        poolSize = 10;
        AIPool = new Enemy[poolSize];
        for (int i = 0; i < poolSize; ++i)
        {
            AIPool[i] = Instantiate(RiflemanPrefab).GetComponent<Enemy>();
        }
        spawnCooldown = 3.5f;
        cooldownTimer = 0.0f;
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; ++i)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canSpawn)
        {
            if (cooldownTimer >= spawnCooldown)
            {
                Enemy enemy = GetInactiveEnemy();
                if (enemy != null)
                {
                    enemy.Initialize(spawnPoints[Random.Range(0, transform.childCount)]);
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

    public static void StartWithTarget(Character target)
    {
        initialTarget = target;
    }

    private Enemy GetInactiveEnemy()
    {
        Enemy enemy = null;
        foreach (Enemy nme in AIPool)
        {
            if (!nme.gameObject.activeSelf)
            {
                enemy = nme;
                enemy.SetTarget(initialTarget);
                break;
            }
        }
        return enemy;
    }
}
