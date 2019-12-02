using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : UIButton
{
    public override void Activate()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
