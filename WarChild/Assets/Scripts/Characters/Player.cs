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
        gameObject.SetActive(true);
        body = GetComponent<Rigidbody>();
        equippedWeapon = Instantiate(PlayerInventory.equippedWeapon).GetComponent<Weapon>();
        GameEventManager.Pause += Pause;
        GameEventManager.UnPause += UnPause;

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
        GameEventManager.TriggerGameOver();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MissionFail");
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        gameObject.SetActive(false);
    }

    private void UnPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
