using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExterminationManager : MissionManager
{

    public int killGoal;
    public int killCount;
    public AIManager aIManager;

    public static int liveEnemies;
    private int maxLiving;

    // Start is called before the first frame update
    void Start()
    {
        liveEnemies = 0;
        maxLiving = aIManager.GetPoolSize();

        killGoal = 20;
        killCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerHUD.objective.text = "Slaughter the enemy! " + killCount + "/" + killGoal;
        if (killCount >= killGoal)
            Extract();
        else if (liveEnemies < maxLiving)
        {
            Enemy enemy = aIManager.GetInactiveEnemy();
            if (enemy != null)
            {
                Transform[] spawnPoints = aIManager.GetSpawnPoints();
                enemy.Initialize(spawnPoints[Random.Range(0, spawnPoints.Length - 1)]);
                enemy.Spawn();
            }
        }
    }

    protected override void Extract()
    {
        SceneManager.LoadScene("MissionComplete");
    }
}
