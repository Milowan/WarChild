using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Weapon equippedWeapon;
    protected CharacterStats stats;


    // Update is called once per frame
    void Update()
    {
        
    }

    public CharacterStats GetStats()
    {
        return stats;
    }
}
