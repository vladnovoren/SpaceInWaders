using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MulScale(float mul)
    {
        _scale *= mul;
        if (_scale.magnitude < _dieScale)
        {
            Destroy(gameObject);
        }
    }

    private readonly float _dieScale = 1.0f / (1 << 3);
    private Vector3 _scale;
}
