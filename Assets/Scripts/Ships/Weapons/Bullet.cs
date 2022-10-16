using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rigit_body_ = GetComponent<Rigidbody2D>();
        rigit_body_.velocity = transform.up * speed_;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health other_health = other.GetComponent<Health>();
        if (other_health != null)
        {
            other_health.TakeDamage(damage_);
        }
        Destroy(gameObject);
    }

    private float speed_ = 20.0f;
    private Rigidbody2D rigit_body_;
    private int damage_ = 34;
}
