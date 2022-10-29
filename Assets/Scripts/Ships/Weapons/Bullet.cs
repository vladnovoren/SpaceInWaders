using System;
using System.Collections;
using System.Collections.Generic;
using ObjectsManaging;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = transform.up * Speed;
    }

    public void SetOwnerRole(GameRoles.Roles ownerRole)
    {
        _ownerRole = ownerRole;
    }

    public void SetOwnerWeapon(BaseWeapon weapon)
    {
        _weapon = weapon;
    }

    public int CreatureDamage { get; } = 1;
    public float TripDamage { get; } = 0.1f;
    public float Speed { get; } = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerEnter2DImpl(other);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2DImpl(Collider2D other)
    {
        GameObject otherGameObject = other.gameObject;

        if (TryCollideHealth(otherGameObject))
            return;

        if (TryCollideTrip(otherGameObject))
            return;
        
        // other
    }

    // Collisions with objects with Health
    private bool TryCollideHealth(GameObject other)
    {
        Health health = other.GetComponent<Health>();
        if (health == null)
            return false;
        CollideHealthImpl(health);
        return true;
    } 

    private void CollideHealthImpl(Health health)
    {
        if (GameRoles.AreEnemies(_ownerRole, health.gameObject))
        {
            if (health.TakeDamage(CreatureDamage))
            {
                _weapon.OnKill();
            }
        }
    }

    // Collisions with trips
    private bool TryCollideTrip(GameObject other)
    {
        Trip trip = other.GetComponent<Trip>();
        if (trip == null)
            return false;
        CollideTripImpl(trip);
        return true;
    }

    private void CollideTripImpl(Trip trip)
    {
        trip.TakeDamage(TripDamage);
    }

    private Rigidbody2D _rigidBody;
    private GameRoles.Roles _ownerRole;
    private BaseWeapon _weapon;
}
