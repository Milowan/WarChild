using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePistol : Weapon
{
    protected override void SetStats()
    {
        stats = new MachinePistolStats();
    }
}
