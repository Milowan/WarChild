﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    protected float effectiveRange;

    public float GetRange()
    {
        return effectiveRange;
    }
}