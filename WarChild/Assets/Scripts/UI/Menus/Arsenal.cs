using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arsenal : Menu
{
    private void Awake()
    {
        gameObject.SetActive(false);
        UIManager.OpenArsenal += OpenArsenal;
        UIManager.CloseArsenal += CloseArsenal;
    }
    protected override void Back()
    {
        UIManager.ArsenalClose();
    }

    private void OpenArsenal()
    {
        gameObject.SetActive(true);
    }

    private void CloseArsenal()
    {
        gameObject.SetActive(false);
    }
}
