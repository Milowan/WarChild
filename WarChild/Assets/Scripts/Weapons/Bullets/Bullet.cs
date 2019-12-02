using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float flightSpeed;
    private float movFraction;
    private float damage;
    private Vector3 forward;
    private float lifespan;
    private float age;

    private void Awake()
    {
        lifespan = 5.0f;
        age = 0;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (age < lifespan)
        {
            age += Time.deltaTime;

            movFraction = 1.0f / 20.0f;
            RaycastHit hit;
            Physics.Raycast(transform.position, forward.normalized, out hit, flightSpeed * movFraction);
            Debug.DrawRay(transform.position, forward * flightSpeed * movFraction, Color.black);
            if (hit.collider != null)
            {
                Character character;
                if (character = hit.collider.GetComponent<Character>())
                {
                    character.TakeDamage(damage);
                }
                Despawn();
            }

            transform.position += forward * flightSpeed * movFraction;
        }
        else
        {
            Despawn();
        }
    }

    public void Initialize(Transform startPoint, Vector3 direction, float speed, float dmg)
    {
        forward = direction;
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
}
