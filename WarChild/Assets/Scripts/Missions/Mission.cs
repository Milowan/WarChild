using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission
{
    public bool unlocked;
    public bool completed;
    private Mission next;
    private Mission prev;
    private string name;

    public Mission(string mName, bool active = false, Mission pMission = null)
    {
        name = mName;
        unlocked = active;
        completed = false;
        prev = pMission;
        if (prev != null)
        { 
            prev.SetNext(this);
            if (prev.completed)
                Unlock();
        }
    }

    public void SetNext(Mission nMission)
    {
        next = nMission;
    }

    public void Unlock()
    {
        unlocked = true;
    }

    public string GetName()
    {
        return name;
    }
}
