using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public GameObject defaultWeaponPrefab;
    private Rigidbody body;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        equippedWeapon = PlayerInventory.equippedWeapon;
        if (equippedWeapon == null)
        {
            equippedWeapon = Instantiate(defaultWeaponPrefab).GetComponent<Weapon>();
        }
        stats = new PlayerStats();
        stats.SetCurrentHP(stats.GetMaxHealth());
    }

    public Rigidbody GetBody()
    {
        return body;
    }

    protected override void Die()
    {
        SceneManager.LoadScene("MissionFail");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
