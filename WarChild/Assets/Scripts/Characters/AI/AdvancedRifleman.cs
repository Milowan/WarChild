using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedRifleman : Enemy
{
    protected override void SetStats()
    {
        stats = new AdvancedRiflemanStats();
        stats.SetCurrentHP(stats.GetMaxHealth());
        AdvancedRiflemanStats mStats = (AdvancedRiflemanStats)stats;
        agent.stoppingDistance = mStats.GetRange() / 10f;
    }
}
