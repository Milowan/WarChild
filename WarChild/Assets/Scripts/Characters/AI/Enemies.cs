using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Character
{
    // Start is called before the first frame update
    void Start()
    {
        AIController.AIEventQueue += Wander;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Wander()
    {

    }


}
