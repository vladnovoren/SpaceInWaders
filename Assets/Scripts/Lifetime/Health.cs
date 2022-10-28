using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }

    private int _health = 100;
}
