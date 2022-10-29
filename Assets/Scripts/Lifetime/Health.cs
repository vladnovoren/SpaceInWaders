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

    public int Value { get; private set; } = 3;

    public bool TakeDamage(int damage)
    {
        Value -= damage;
        if (Value <= 0)
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }
}
