using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRifleman : Enemy
{ 
    protected override void SetStats()
    {
        stats = new BasicRiflemanStats();
        stats.SetCurrentHP(stats.GetMaxHealth());
        BasicRiflemanStats mStats = (BasicRiflemanStats)stats;
        agent.stoppingDistance = mStats.GetRange();
    }
}
