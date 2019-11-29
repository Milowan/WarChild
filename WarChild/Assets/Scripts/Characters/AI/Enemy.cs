using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public GameObject weaponPrefab;
    private Vector3 destination;
    private float wanderRangeMin;
    private float wanderRangeMax;
    private bool alert;
    private bool isLast;
    protected NavMeshAgent agent;


    // Start is called before the first frame update
    void Awake()
    {
        AIController.Wander += Wander;
        isLast = false;
        agent = GetComponent<NavMeshAgent>();
        equippedWeapon = Instantiate(weaponPrefab).GetComponent<Weapon>();
        wanderRangeMin = -40f;
        wanderRangeMax = 40f;
        alert = false;

        SetStats();
        gameObject.SetActive(false);
        equippedWeapon.gameObject.SetActive(false);
    }

    protected virtual void SetStats()
    {

    }// Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        CheckTarget();
        if (alert)
            CheckFire();

        if (equippedWeapon != null)
        {
            weaponPosition = transform.right * 0.5f;
            equippedWeapon.gameObject.transform.position = transform.position + weaponPosition;
            equippedWeapon.gameObject.transform.rotation = transform.rotation;
        }
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

    public void IsLast()
    {
        isLast = true;
    }

    private void Wander()
    {
        if (gameObject.activeSelf)
        { 
            agent.SetDestination(new Vector3(Random.Range(wanderRangeMin, wanderRangeMax) + transform.position.x, transform.position.y, Random.Range(wanderRangeMin, wanderRangeMax) + transform.position.z)); 
        }
    }

    private void Chase()
    {
        if (gameObject.activeSelf)
        {
            alert = true;
            agent.SetDestination(GetComponent<Scanner>().GetTarget().transform.position);
        }
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

    public void SetTarget(Character target)
    {
        GetComponent<Scanner>().SetTarget(target);
        if (target != null)
        {
            AIController.Wander -= Wander;
            AIController.Chase -= Chase;
            AIController.Chase += Chase;
        }
    }

    protected override void Die()
    {
        if (isLast)
            DefenseManager.waveOver = true;
        isLast = false;
        alert = false;
        gameObject.SetActive(false);
        equippedWeapon.gameObject.SetActive(false);
    }
}
