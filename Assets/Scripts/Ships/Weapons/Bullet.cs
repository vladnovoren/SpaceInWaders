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
        _rigidBody.velocity = transform.up * Speed;
    }

    public void SetOwner(GameObject owner)
    {
        _owner = owner;
    }

    public int CreatureDamage { get; } = 34;

    public float TripDamage { get; } = 0.5f;
    public float Speed { get; } = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollisionManager.ResponseBullet(gameObject, other.gameObject);
    }

    private Rigidbody2D _rigidBody;
    private GameObject _owner;
}
