using UnityEngine;
using System.Collections;

public class RifleStats : WeaponStats
{

    // Use this for initialization
    public RifleStats()
    {
        atkSp = 3.4f;
        dmg = 10f;
        flightSpeed = 400f;
        clipSize = 30;
        reloadSp = 1.5f;
        accuracy = 5f;
    }

}
