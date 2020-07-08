using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D6 : MonoBehaviour
{
    public Vector3 diceVelocity;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        diceVelocity = rb.velocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);

            rb.AddForce(transform.up * 1000);
            rb.AddTorque(dirX, dirY, dirZ);
        }
    }
}
