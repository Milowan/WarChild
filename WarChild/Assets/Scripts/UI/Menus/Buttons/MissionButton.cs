using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionButton : UIButton
{
    public string targetLevelName;

    public override void Activate()
    {
        SceneManager.LoadScene(targetLevelName);
    }
}
