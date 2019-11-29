using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Weapon equippedWeapon;
    protected CharacterStats stats;
    private Vector3 weaponPosition;


    // Update is called once per frame
    void Update()
    {
        if (equippedWeapon != null)
        {
            weaponPosition = transform.right * 0.5f;
            equippedWeapon.gameObject.transform.position = transform.position + weaponPosition;
            equippedWeapon.gameObject.transform.rotation = transform.rotation;
        }
    }

    public CharacterStats GetStats()
    {
        return stats;
    }

    public void PullTrigger()
    {
        equippedWeapon.Trigger();
    }

    public void TakeDamage(float damage)
    {
        if (stats.ReduceCurrentHP(damage / stats.GetArmour()) <= 0.0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {

    }
}
