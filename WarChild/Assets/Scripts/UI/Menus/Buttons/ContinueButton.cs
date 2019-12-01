using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : UIButton
{ 
    public override void Activate()
    {
        UIManager.CloseExMenu();
        GameEventManager.TriggerUnPause();
    }
}
