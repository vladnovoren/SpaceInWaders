using System.Collections;
using System.Collections.Generic;
using ObjectsManaging;
using UnityEngine;

public class PlayerWeapon : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        _reloadTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        TryShoot();
    }

    public override void OnKill()
    {
        owner.OnKill();
    }

    private void TryShoot()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            var spawnedBullet = Shoot();
            if (spawnedBullet == null) return;
            spawnedBullet.SetOwnerRole(GameRoles.Roles.Player);
        }
    }

    [SerializeField] protected PlayerShip owner;
}
