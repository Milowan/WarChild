using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    protected float maxHealth;
    protected float currentHP;
    protected float movSpeed;
    protected float armour;

    public float GetMovSpeed()
    {
        return movSpeed;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHP()
    {
        return currentHP;
    }

    public float GetArmour()
    {
        return armour;
    }
}
