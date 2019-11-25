using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats
{
    //Shots per second
    protected float atkSp;
    protected float dmg;
    protected float range;
    protected int clipSize;
    //in seconds
    protected float reloadSp;
    //percentage
    protected float accuracy;

    public float GetAtkSpeed()
    {
        return atkSp;
    }

    public float GetDamage()
    {
        return dmg;
    }

    public float GetRange()
    {
        return range;
    }

    public int GetClipSize()
    {
        return clipSize;
    }

    public float GetReloadSpeed()
    {
        return reloadSp;
    }

    public float GetAccuracy()
    {
        return accuracy;
    }
    
}
