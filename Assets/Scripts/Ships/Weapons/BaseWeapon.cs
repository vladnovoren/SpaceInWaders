using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Bullet bullet;

    public BaseWeapon()
    {
    }
 
    public BaseWeapon(float reloadTime)
    {
        _reloadTime = reloadTime;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Shoot()
    {
        if (CheckReloadTime())
        {
            _lastShootTime = Time.time;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
    
    private bool CheckReloadTime()
    {
        return !(Time.time - _lastShootTime < _reloadTime);
    }

    protected float _reloadTime = 1.0f;
    protected float _lastShootTime = 0.0f;
}
