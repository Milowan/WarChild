using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float flightSpeed;
    private float damage;
    private Renderer renderer;
    private Vector3 forward;
    private float lifespan;
    private float age;

    private void Awake()
    {
        lifespan = 1.0f;
        age = 0;
        gameObject.SetActive(false);
        renderer = GetComponent<Renderer>();
        Color color = new Color();
        color.r = 200f;
        color.g = 175f;
        color.b = 50f;
        color.a = 0.5f;
        renderer.material.SetColor("_Color", color);
    }

    private void Update()
    {
        if (age < lifespan)
        {
            age += Time.deltaTime;

            RaycastHit hit;
            float hitCheckRange = 5.0f;
            Physics.Raycast(transform.position, forward, out hit, hitCheckRange);
            if (hit.collider != null)
            {
                Character character;
                if (character = hit.collider.GetComponent<Character>())
                {
                    character.TakeDamage(damage);
                    Despawn();
                }
            }

            transform.position += forward * flightSpeed * Time.deltaTime;
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
