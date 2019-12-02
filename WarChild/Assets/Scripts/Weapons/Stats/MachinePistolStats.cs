using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePistolStats : WeaponStats
{
    public MachinePistolStats()
    {
        atkSp = 15f;
        dmg = 8f;
        flightSpeed = 400f;
        clipSize = 40;
        reloadSp = 0.75f;
        accuracy = 10f;
    }
}
