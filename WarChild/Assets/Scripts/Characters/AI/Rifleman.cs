using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifleman : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        stats = new RiflemanStats();
        stats.SetCurrentHP(stats.GetMaxHealth());
    }
}
