using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public GameObject weaponPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        AIController.Wander += Wander;
        equippedWeapon = Instantiate(weaponPrefab).GetComponent<Weapon>();
    }

    private void Wander()
    {

    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        equippedWeapon.gameObject.SetActive(true);
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
        equippedWeapon.gameObject.SetActive(false);
    }
}
