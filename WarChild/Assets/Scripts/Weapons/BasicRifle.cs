﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRifle : Weapon
{
    protected override void SetStats()
    {
        stats = new BasicRifleStats();
    }
}
