using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCompleteMenu : Menu
{
    // Start is called before the first frame update
    void Awake()
    {
        MissionTracker.currentMission.Complete();
        MissionData.Save();
    }

}
