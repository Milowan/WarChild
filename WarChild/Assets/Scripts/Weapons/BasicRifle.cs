using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRifle : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        stats = new BasicRifleStats();
        currentClip = stats.GetClipSize();
        cooldown = 1 / stats.GetAtkSpeed();
        cdTimer = cooldown;
    }

    public override void Fire()
    {
        base.Fire();
        Vector3 forward = Quaternion.AngleAxis(Random.Range(-stats.GetAccuracy(), stats.GetAccuracy()), transform.up) * transform.forward;
        forward = Quaternion.AngleAxis(Random.Range(-stats.GetAccuracy(), stats.GetAccuracy()), transform.right) * forward;
        pool.GetFreeBullet().Initialize(transform, transform.forward, stats.GetSpeed(), stats.GetDamage());
        cdTimer = 0.0f;
    }
}
