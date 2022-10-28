using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _weapon = weaponGameObject.GetComponent<EnemyWeapon>();
    }
    
    // Update is called once per frame
    void Update()
    {
        _rigidBody.MovePosition(_startPosition +
                                 _amplitude * _moveSpeed *
                                 (float)Math.Sin(Time.realtimeSinceStartup) * Vector2.right 
                                 );
    }

    public void Shoot()
    {
        _weapon.TryShoot();
    }
    
    private Rigidbody2D _rigidBody;
    private Vector2 _startPosition;
    private readonly float _moveSpeed = 1f;
    private readonly float _amplitude = 1f;

    [SerializeField] protected GameObject weaponGameObject;
    private EnemyWeapon _weapon;
}
