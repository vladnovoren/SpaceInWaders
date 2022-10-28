using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void TakeDamage(float damage)
    {
        gameObject.transform.localScale -= Vector3.one * damage;
        if (gameObject.transform.localScale.magnitude < _dieScale)
            Destroy(gameObject);
    }

    private readonly float _dieScale = 0.25f;
}
