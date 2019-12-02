using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : Menu
{
    Transform missionButtonContainer;

    private void Awake()
    {
        gameObject.SetActive(false);
        UIManager.OpenNavigation += OpenNavigation;
        UIManager.CloseNavigation += CloseNavigation;

        missionButtonContainer = transform.GetChild(1);
        SetMissionButtons();
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

    private void SetMissionButtons()
    {
        foreach (Transform button in missionButtonContainer)
        {
            Text mButton = button.GetChild(0).GetComponent<Text>();
            for (int i = 0; i < MissionData.missions.Count; ++i)
            {
                if (mButton.text == MissionData.missions[i].GetName())
                {
                    button.GetComponent<MissionButton>().targetLevel = MissionData.missions[i];
                    break;
                }
            }
        }
    }
}
