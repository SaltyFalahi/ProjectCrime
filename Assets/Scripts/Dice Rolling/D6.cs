using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D6 : MonoBehaviour
{
    public Vector3 diceVelocity;

    public List<D6Result> sides;

    public float lifetime;

    public int value;

    Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        diceVelocity = rb.velocity;

        if (diceVelocity == Vector3.zero)
        {
            for (int i = 0; i < sides.Count; i++)
            {
                if (sides[i].landed)
                {
                    value = sides[i].number;
                }
            }
        }
    }
}
