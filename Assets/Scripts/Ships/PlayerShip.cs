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
        TryRun();
    }

    public void OnKill()
    {
        ++Scores;
    }

    private bool TryRun()
    {
        if (IsRun())
        {
            RunImpl();
            return true;
        }

        return false;
    }

    private bool IsRun()
    {
        return Input.GetButton("Horizontal") || Input.GetButton("Vertical");
    }

    private void RunImpl()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myRigitBody.MovePosition(myRigitBody.position + moveInput * moveSpeed);        
    }

    public int Scores { get; private set; } = 0;

    private float moveSpeed = 0.05f;
    private Rigidbody2D myRigitBody;
}
