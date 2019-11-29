using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    private void Awake()
    {
        UIManager.OpenNavigation += OpenNavigation;
        UIManager.CloseNavigation += CloseNavigation;
        UIManager.OpenArsenal += OpenArsenal;
        UIManager.CloseArsenal += CloseArsenal;
    }

    protected override void Back()
    {
        Application.Quit();
    }

    private void OpenNavigation()
    {
        gameObject.SetActive(false);
    }

    private void CloseNavigation()
    {
        gameObject.SetActive(true);
    }

    private void OpenArsenal()
    {
        gameObject.SetActive(false);
    }

    private void CloseArsenal()
    {
        gameObject.SetActive(true);
    }
}
