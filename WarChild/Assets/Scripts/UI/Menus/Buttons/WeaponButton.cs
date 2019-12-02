using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponButton : UIButton
{

    public GameObject weapon;

    public override void Activate()
    {
        PlayerInventory.equippedWeapon = weapon;
    }
}
