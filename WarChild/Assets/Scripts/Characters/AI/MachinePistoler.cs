using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePistoler : Enemy
{
    protected override void SetStats()
    {
        stats = new MachinePistolerStats();
        stats.SetCurrentHP(stats.GetMaxHealth());
        MachinePistolerStats mStats = (MachinePistolerStats)stats;
        agent.stoppingDistance = mStats.GetRange() / 10f;
    }
}
