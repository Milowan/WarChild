using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : UIButton
{
    public override void Activate()
    {
        SceneManager.LoadScene(MissionTracker.currentMission);
    }
}
