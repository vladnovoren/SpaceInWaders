using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var playerShip = other.gameObject.GetComponent<PlayerShip>();
        var health = other.gameObject.GetComponent<Health>();
        if (playerShip == null || health == null) return;
        health.AddBonus();
        Destroy(gameObject);
    }
}
