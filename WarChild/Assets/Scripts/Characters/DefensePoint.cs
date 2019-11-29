using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefensePoint : Character
{
    // Start is called before the first frame update
    void Start()
    {
        stats = new DefensePointStats();
        stats.SetCurrentHP(stats.GetMaxHealth());
    }

    protected override void Die()
    {
        SceneManager.LoadScene("MissionFail");
    }
}
