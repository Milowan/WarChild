using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected WeaponStats stats;
    private bool active;
    private float cdTimer;
    private int currentClip;

    private void Awake()
    {
        cdTimer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {

    }

    public void Trigger()
    {
        float cooldown = 1 / stats.GetAtkSpeed();
        if (cdTimer < cooldown)
        {
            cdTimer += Time.deltaTime;
        }
        else
        {
            Fire();
        }
    }
}
