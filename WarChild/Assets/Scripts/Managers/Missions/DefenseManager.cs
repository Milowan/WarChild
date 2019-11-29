using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseManager : MissionManager
{
    public Character defensePoint;

    // Start is called before the first frame update
    void Start()
    {
        AIManager.StartWithTarget(defensePoint);
    }
}
