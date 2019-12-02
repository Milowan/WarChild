using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionButton : UIButton
{
    public Mission targetLevel;

    public override void Activate()
    {
        MissionTracker.SetCurrentMission(targetLevel);
        if (targetLevel.unlocked)
            SceneManager.LoadScene(targetLevel.GetName());
    }
}
