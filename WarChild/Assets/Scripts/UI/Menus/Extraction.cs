using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extraction : Menu
{
    private void Awake()
    {
        gameObject.SetActive(false);
        UIManager.OpenExtraction += OpenExtraction;
        UIManager.CloseExtraction += CloseExtraction;
    }

    private void OpenExtraction()
    {
        gameObject.SetActive(true);
    }

    private void CloseExtraction()
    {
        gameObject.SetActive(false);
    }
}
