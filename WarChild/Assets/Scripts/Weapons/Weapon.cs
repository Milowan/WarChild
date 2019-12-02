using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected WeaponStats stats;
    protected BulletPool pool;
    private bool active;
    private bool reloading;
    private float reloadTimer;
    protected int currentClip;
    protected float cooldown;
    protected float cdTimer;

    private void Awake()
    {
        cdTimer = 0;
        pool = GameObject.Find("BulletPool").GetComponent<BulletPool>();
        reloading = false;
        SetStats();
        currentClip = stats.GetClipSize();
        cooldown = 1 / stats.GetAtkSpeed();
        cdTimer = cooldown;
    }

    protected virtual void SetStats()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (reloading)
        {
            Reload();
        }
        else
        {
            reloadTimer = 0.0f;
        }
    }

    private void Fire()
    {
        currentClip--;
        Vector3 forward = Quaternion.AngleAxis(Random.Range(-stats.GetAccuracy(), stats.GetAccuracy()), transform.up) * transform.forward;
        forward = Quaternion.AngleAxis(Random.Range(-stats.GetAccuracy(), stats.GetAccuracy()), transform.right) * forward;
        pool.GetFreeBullet().Initialize(transform, transform.forward, stats.GetSpeed(), stats.GetDamage());
        cdTimer = 0.0f;
    }

    public void Trigger()
    {
        if (currentClip > 0)
        {
            if (cdTimer < cooldown)
            {
                cdTimer += Time.deltaTime;
            }
            else
            {
                Fire();
            }
        }
        else
        {
            reloading = true;
        }
    }

    private void Reload()
    {
        if (reloadTimer < stats.GetReloadSpeed())
        {
            reloadTimer += Time.deltaTime;
        }
        else
        {
            currentClip = stats.GetClipSize();
            reloading = false;
        }
    }

    public WeaponStats GetStats()
    {
        return stats;
    }

    public int InClip()
    {
        return currentClip;
    }
}
