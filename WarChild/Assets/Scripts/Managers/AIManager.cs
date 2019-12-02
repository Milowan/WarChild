using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{

    private Enemy[] AIPool;
    private int poolSize;
    public GameObject BasicRiflemanPrefab;
    public GameObject AdvancedRiflemanPrefab;
    public GameObject MachinePistolerPrefab;
    private Transform[] spawnPoints;
    private Character initialTarget;


    // Start is called before the first frame update
    void Awake()
    {
        poolSize = 30;
        AIPool = new Enemy[poolSize];
        for (int i = 0; i < poolSize; ++i)
        {
            if (i < poolSize / 3)
                AIPool[i] = Instantiate(BasicRiflemanPrefab).GetComponent<Enemy>();
            else if (i < poolSize * (2 / 3))
                AIPool[i] = Instantiate(AdvancedRiflemanPrefab).GetComponent<Enemy>();
            else
                AIPool[i] = Instantiate(MachinePistolerPrefab).GetComponent<Enemy>();
        }
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; ++i)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    public void StartWithTarget(Character target)
    {
        initialTarget = target;
    }

    public Transform[] GetSpawnPoints()
    {
        return spawnPoints;
    }

    public Enemy GetInactiveEnemy()
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

    public int GetPoolSize()
    {
        return AIPool.Length;
    }
}
