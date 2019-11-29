using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject prefab;
    private Bullet[] pool;

    // Start is called before the first frame update
    void Start()
    {
        int poolSize = 40;
        pool = new Bullet[poolSize];
        for (int i = 0; i < poolSize; ++i)
        {
            pool[i] = Instantiate(prefab).GetComponent<Bullet>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Bullet GetFreeBullet()
    {
        Bullet bullet = null;

        foreach (Bullet shot in pool)
        {
            if (!shot.gameObject.activeSelf)
            {
                bullet = shot;
                break;
            }
        }

        return bullet;
    }
}
