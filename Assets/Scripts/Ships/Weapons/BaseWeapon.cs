using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
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
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Bullet bullet;
}
