using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private void Awake()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        myRigitBody.MovePosition(startPosition +
                                 Vector2.right * amplitude *
                                 moveSpeed * (float)Math.Sin(Time.realtimeSinceStartup)
                                 );
    }
    
    private Rigidbody2D myRigitBody;
    private Vector2 startPosition;
    private float moveSpeed = 1f;
    private float amplitude = 1f;
}
