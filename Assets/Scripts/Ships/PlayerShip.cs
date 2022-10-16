using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    private void Awake()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRun())
            Run();
        Shoot();
    }

    bool IsRun()
    {
        return Input.GetButton("Horizontal") || Input.GetButton("Vertical");
    }

    void Run()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myRigitBody.MovePosition(myRigitBody.position + moveInput * moveSpeed);        
    }

    void Shoot()
    {
    }
    
    private float moveSpeed = 0.05f;
    private Rigidbody2D myRigitBody;
}
