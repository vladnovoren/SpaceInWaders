using System;
using System.Collections;
using System.Collections.Generic;
using ObjectsManaging;
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

    public override void OnKill()
    {
    }
    
    public void TryShoot()
    {
        if (CheckFriendlyFire()) return;
        var spawnedBullet = Shoot();
        if (spawnedBullet != null)
            spawnedBullet.SetOwnerRole(GameRoles.Roles.Enemy);
    }

    bool CheckFriendlyFire()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, transform.up); 
        if (hit.collider != null && hit.collider.gameObject.GetComponent<EnemyShipTag>() != null)
            return true;
        return false;
    }
}
