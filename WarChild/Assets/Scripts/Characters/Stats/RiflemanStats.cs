using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflemanStats : EnemyStats
{
    // Start is called before the first frame update
    public RiflemanStats()
    {
        maxHealth = 100f;
        movSpeed = 0.25f;
        effectiveRange = 40f;
        armour = 1.4f;
    }
}
