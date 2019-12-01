using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Weapon equippedWeapon;
    protected CharacterStats stats;
    protected Vector3 weaponPosition;


    private void Start()
    {
        GameEventManager.Pause += Pause;
        GameEventManager.UnPause += UnPause;
    }

    public void UpdateWeapon(float pitch, float yaw)
    {
        
        if (equippedWeapon != null)
        {
            weaponPosition = transform.right * 0.5f;
            equippedWeapon.gameObject.transform.position = transform.position + weaponPosition;
            equippedWeapon.gameObject.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        
    }

    public CharacterStats GetStats()
    {
        return stats;
    }

    public Weapon GetWeapon()
    {
        return equippedWeapon;
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

    public float GetHealthFraction()
    {
        return stats.GetCurrentHP() / stats.GetMaxHealth();
    }

    protected virtual void Die()
    {

    }

    private void Pause()
    {
        gameObject.SetActive(false);
    }

    private void UnPause()
    {
        gameObject.SetActive(true);
    }
}
