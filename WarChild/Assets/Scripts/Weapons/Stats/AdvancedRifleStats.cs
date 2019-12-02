using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedRifleStats : WeaponStats
{
    public AdvancedRifleStats()
    {
        atkSp = 5f;
        dmg = 12f;
        flightSpeed = 400f;
        clipSize = 30;
        reloadSp = 1.0f;
        accuracy = 3f;
    }
}
