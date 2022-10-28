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
        _reloadTime = 3f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TryShoot()
    {
        if (!CheckFriendlyFire())
        {
            Shoot();
        }
    }

    bool CheckFriendlyFire()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, transform.up); 
        if (hit.collider != null && hit.collider.gameObject.GetComponent<EnemyShipTag>() != null)
            return true;
        return false;
    }
}
