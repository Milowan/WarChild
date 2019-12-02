using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedRifle : Weapon
{
    protected override void SetStats()
    {
        stats = new AdvancedRifleStats();
    }
}
