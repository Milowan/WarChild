using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float flightSpeed;
    private float damage;
    private float lifespan;
    private float age;

    private void Awake()
    {
        lifespan = 1.5f;
        age = 0;
    }

    private void Update()
    {
        if (age < lifespan)
        {
            age += Time.deltaTime;
            transform.position += transform.forward * flightSpeed * Time.deltaTime;
            Debug.DrawRay(transform.position, transform.forward * 5f, Color.black);
        }
        else
        {
            Despawn();
        }
    }

    public void Initialize(Transform startPoint, float speed, float dmg)
    {
        transform.position = startPoint.position + startPoint.forward;
        transform.rotation = startPoint.rotation;
        gameObject.SetActive(true);
        flightSpeed = speed;
        damage = dmg;
    }

    private void Despawn()
    {
        age = 0;
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character;
        if (character = other.GetComponent<Character>())
        {
            character.TakeDamage();
            Despawn();
        }
    }
}
