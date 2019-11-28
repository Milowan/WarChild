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

    // Start is called before the first frame update
    void Start()
    {
        poolSize = 4;
        AIPool = new Enemy[poolSize];
        for (int i = 0; i < poolSize; ++i)
        {
            AIPool[i] = Instantiate(RiflemanPrefab).GetComponent<Enemy>();
        }
        spawnCooldown = 3.5f;
        cooldownTimer = spawnCooldown;
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; ++i)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooldownTimer >= spawnCooldown)
        {
            Enemy enemy = GetInactiveEnemy();
            if (enemy != null)
            {
                enemy.Initialize(spawnPoints[Random.Range(0, transform.childCount)]);
                enemy.Spawn();
            }
            cooldownTimer = 0.0f;
        }

        cooldownTimer += Time.deltaTime;
    }

    private Enemy GetInactiveEnemy()
    {
        Enemy enemy = null;
        foreach (Enemy nme in AIPool)
        {
            if (!nme.gameObject.activeSelf)
            {
                enemy = nme;
                break;
            }
        }

        return enemy;
    }
}
