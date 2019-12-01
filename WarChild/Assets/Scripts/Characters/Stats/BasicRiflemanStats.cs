using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRiflemanStats : EnemyStats
{
    // Start is called before the first frame update
    public BasicRiflemanStats()
    {
        maxHealth = 20f;
        movSpeed = 0.25f;
        effectiveRange = 40f;
        armour = 1.4f;
    }
}
