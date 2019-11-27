using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats
{
    //Shots per second
    protected float atkSp;
    protected float dmg;
    protected float flightSpeed;
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

    public float GetSpeed()
    {
        return flightSpeed;
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
