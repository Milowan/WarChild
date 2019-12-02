using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedRiflemanStats : EnemyStats
{ 
    public AdvancedRiflemanStats()
    {
        maxHealth = 25f;
        movSpeed = 0.25f;
        effectiveRange = 60f;
        armour = 1.4f;
    }
}
