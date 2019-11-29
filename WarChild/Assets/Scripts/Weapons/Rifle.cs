using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        stats = new RifleStats();
        currentClip = stats.GetClipSize();
        cooldown = 1 / stats.GetAtkSpeed();
        cdTimer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Fire()
    {
        pool.GetFreeBullet().Initialize(transform, transform.forward, stats.GetSpeed(), stats.GetDamage());
        cdTimer = 0.0f;
    }
}
