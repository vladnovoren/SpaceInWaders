using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        myRigitBody.MovePosition(startPosition +
                                 Vector2.right *
                                 speed * (float)Math.Sin(Time.realtimeSinceStartup)
                                 );
    }

    private Rigitbody2D myRigitBody;
    private Vector2 startPosition;
    private float speed = 1f;
}
