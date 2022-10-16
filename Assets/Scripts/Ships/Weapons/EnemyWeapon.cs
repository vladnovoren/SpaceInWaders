using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TryShoot();
    }

    void TryShoot()
    {
        if (CheckTime())
        {
            Shoot();
        }
    }

    bool CheckTime()
    {
        currDeltaTime += Time.deltaTime;
        if (currDeltaTime >= timeBtwShoots)
        {
            currDeltaTime -= timeBtwShoots;
            return true;
        }
        return false;
    }

    private float currDeltaTime = 0f;
    private float timeBtwShoots = 0.3f;
}
