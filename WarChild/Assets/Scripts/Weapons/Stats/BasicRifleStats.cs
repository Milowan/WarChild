using UnityEngine;
using System.Collections;

public class BasicRifleStats : WeaponStats
{

    // Use this for initialization
    public BasicRifleStats()
    {
        atkSp = 3.4f;
        dmg = 10f;
        flightSpeed = 400f;
        clipSize = 20;
        reloadSp = 1.5f;
        accuracy = 5f;
    }

}
