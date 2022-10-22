using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = transform.up * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }

    private readonly float _speed = 1.0f;
    private readonly int _damage = 34;

    private Rigidbody2D _rigidBody;
}
