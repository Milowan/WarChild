using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void InputEvent();

    public static InputEvent Pause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            PauseGame();
        }
    }

    private static void PauseGame()
    {
        if (Pause != null)
        {
            Pause();
        }
    }
}
