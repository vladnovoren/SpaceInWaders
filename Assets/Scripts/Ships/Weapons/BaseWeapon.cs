using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Bullet bullet;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public abstract void OnKill();

    protected Bullet Shoot()
    {
        if (CheckReloadTime())
        {
            _lastShootTime = Time.time;
            var spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            spawnedBullet.SetOwnerWeapon(this);
            return spawnedBullet;
        }

        return null;
    }
    
    private bool CheckReloadTime()
    {
        return !(Time.time - _lastShootTime < _reloadTime);
    }
    
    protected float _reloadTime = 1.0f;
    protected float _lastShootTime = 0.0f;
}
