using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public GameObject weaponPrefab;
    private float FieldOfView;
    private Vector3 destination;
    private Vector3 currentV;
    private Rigidbody body;
    private float maxForce;
    private float arrivalRange;
    private float wanderRangeMin;
    private float wanderRangeMax;
    private bool moving;
    private bool alert;


    // Start is called before the first frame update
    void Awake()
    {
        AIController.Wander += Wander;
        equippedWeapon = Instantiate(weaponPrefab).GetComponent<Weapon>();
        body = GetComponent<Rigidbody>();
        maxForce = 5f;
        arrivalRange = 10f;
        gameObject.SetActive(false);
        equippedWeapon.gameObject.SetActive(false);
        moving = false;
        wanderRangeMin = -40f;
        wanderRangeMax = 40f;
        alert = false;
        SetStats();
    }

    protected virtual void SetStats()
    {

    }

    private void FixedUpdate()
    {
        currentV = body.velocity;
        CheckTarget();
        if (moving)
            Steer();
        if (alert)
            CheckFire();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            destination = -(transform.forward * 3f);
        }
    }

    private void Steer()
    {
        Vector3 target = destination - transform.position;
        target = target.normalized * stats.GetMovSpeed();
        target -= currentV;
        target = Vector3.ClampMagnitude(target, maxForce);
        currentV = Vector3.ClampMagnitude(currentV + target, stats.GetMovSpeed());
        transform.position += currentV;
        transform.forward = currentV.normalized;
        EnemyStats mStats = (EnemyStats)stats;
        if ((destination - transform.position).magnitude < arrivalRange || (GetComponent<Scanner>().GetTarget() && (GetComponent<Scanner>().GetTarget().transform.position - transform.position).magnitude < mStats.GetRange()))
            moving = false;
    }

    private void CheckFire()
    {
        Character target = GetComponent<Scanner>().GetTarget().GetComponent<Character>();
        float angle = Vector3.Angle(transform.position, target.transform.position);
        if (angle < equippedWeapon.GetStats().GetAccuracy())
        {
            RaycastHit hit;
            EnemyStats mStats = (EnemyStats)stats;
            Physics.Raycast(transform.position, transform.forward, out hit, mStats.GetRange());
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Character>() == target)
                {
                    PullTrigger();
                }
            }
        }

    }

    private void Wander()
    {
        if (gameObject.activeSelf)
        {
            moving = true;
        }

        destination.Set(Random.Range(wanderRangeMin, wanderRangeMax) + transform.position.x, transform.position.y, Random.Range(wanderRangeMin, wanderRangeMax) + transform.position.z); 
    }

    private void Chase()
    {
        moving = true;
        alert = true;
        destination = GetComponent<Scanner>().GetTarget().transform.position;
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        equippedWeapon.gameObject.SetActive(true);
        stats.SetCurrentHP(stats.GetMaxHealth());
    }

    public void Initialize(Transform tf)
    {
        transform.position = tf.position;
        transform.rotation = tf.rotation;
        destination.Set(Random.Range(wanderRangeMin, wanderRangeMax) + transform.position.x, transform.position.y, Random.Range(wanderRangeMin, wanderRangeMax) + transform.position.z);
        moving = true;
    }

    private void CheckTarget()
    {
        Character target = GetComponent<Scanner>().GetTarget();
        if (target != null)
        {
            AIController.Wander -= Wander;
            AIController.Chase -= Chase;
            AIController.Chase += Chase;
        }
    }

    protected override void Die()
    {
        alert = false;
        gameObject.SetActive(false);
        equippedWeapon.gameObject.SetActive(false);
    }
}
