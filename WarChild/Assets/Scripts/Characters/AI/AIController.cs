using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public delegate void AIEvent();

    public static event AIEvent AIEventQueue;

    // Update is called once per frame
    void FixedUpdate()
    {
        RunEventQueue();
    }

    public static void RunEventQueue()
    {
        if (AIEventQueue != null)
        {
            AIEventQueue();
        }
    }
}
