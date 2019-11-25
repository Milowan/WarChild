using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public delegate void AIEvent();

    public static event AIEvent Wander;
    public static event AIEvent Chase;
    public static event AIEvent Shoot;

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
