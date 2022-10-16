using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myRigitBody = GetComponent<Rigidbody2D>();
        myRigitBody.velocity = transform.up * speed;
    }
    
    private float speed = 20.0f;
    private Rigidbody2D myRigitBody;
}
