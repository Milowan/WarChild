using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : Menu
{
    private void Awake()
    {
        gameObject.SetActive(false);
        UIManager.OpenNavigation += OpenNavigation;
        UIManager.CloseNavigation += CloseNavigation;
    }

    protected override void Back()
    {
        UIManager.CloseNav();
    }

    private void OpenNavigation()
    {
        gameObject.SetActive(true);
    }

    private void CloseNavigation()
    {
        gameObject.SetActive(false);
    }
}
