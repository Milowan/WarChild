using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private float FoV;
    private float sightRange;

    private Character target;

    private void Awake()
    {
        FoV = 90f;
        sightRange = 20f;
    }

    private void FixedUpdate()
    {
        int checkCount = 5;
        float angle = -(FoV / 2);
        for (int i = 0; i < checkCount; ++i)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
            RaycastHit hit;
            Physics.Raycast(transform.position, rotation * transform.forward, out hit, sightRange);
            angle += FoV / 4;
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Player>())
                {
                    target = hit.collider.GetComponent<Character>();
                }
            }
        }
    }

    public Character GetTarget()
    {
        return target;
    }

    public void SetTarget(Character mTarget)
    {
        target = mTarget;
    }
}
