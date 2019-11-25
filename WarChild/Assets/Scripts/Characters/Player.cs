using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject defaultWeaponPrefab;
    private Vector3 weaponPosition;

    // Start is called before the first frame update
    void Awake()
    {
        equippedWeapon = PlayerInventory.equippedWeapon;
        if (equippedWeapon == null)
        {
            equippedWeapon = Instantiate(defaultWeaponPrefab).GetComponent<Weapon>();
        }
        stats = new PlayerStats();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        weaponPosition = transform.right * 0.5f;
        equippedWeapon.gameObject.transform.position = transform.position + weaponPosition;
        equippedWeapon.gameObject.transform.rotation = transform.rotation;
    }
}
