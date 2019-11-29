using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public delegate void AIEvent();

    public static event AIEvent Wander;
    public static event AIEvent Chase;

    private float wanderCooldown;
    private float WCTimer;

    private float chaseCooldown;
    private float CCTimer;

    private void Start()
    {
        wanderCooldown = 8f;
        WCTimer = wanderCooldown;
        chaseCooldown = 0.5f;
        CCTimer = chaseCooldown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (WCTimer >= wanderCooldown)
        {
            if (Wander != null)
            {
                Wander();
            }
            WCTimer = 0f;
        }

        if (CCTimer >= chaseCooldown)
        {
            if (Chase != null)
            {
                Chase();
            }
            CCTimer = 0f;
        }

        WCTimer += Time.deltaTime;
        CCTimer += Time.deltaTime;
    }
}
