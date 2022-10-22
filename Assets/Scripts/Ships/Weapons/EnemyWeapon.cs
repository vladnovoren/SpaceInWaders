using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

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
        if (CheckTime() && !CheckFriendlyFire())
        {
            Shoot();
        }
    }

    bool CheckTime()
    {
        _currDeltaTime += Time.deltaTime;
        if (_currDeltaTime < _reloadTime)
            return false;
        _currDeltaTime -= _reloadTime;
        return true;
    }

    bool CheckFriendlyFire()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, transform.up); 
        if (hit.collider != null && hit.collider.gameObject.GetComponent<EnemyShipTag>() != null)
            return true;
        return false;
    }

    private float _currDeltaTime = 0f;
    private readonly float _reloadTime = 1.0f;
}
