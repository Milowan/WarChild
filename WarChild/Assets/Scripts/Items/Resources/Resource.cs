using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    protected string name;
    protected int amount;

    public int GetAmount()
    {
        return amount;
    }

    public void SetAmount(int val)
    {
        amount = val;
    }

    public void AddAmount(int val)
    {
        amount += val;
    }

    public void SubAmount(int val)
    {
        amount -= val;
    }

    public string GetName()
    {
        return name;
    }


}
