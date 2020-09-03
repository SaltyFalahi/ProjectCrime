using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpotlight : MonoBehaviour
{
    public Transform[] points;

    public float speed;
    public float radius;

    int current;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(points[current].transform.position, transform.position) < radius)
        {
            current++;
            if (current >= points.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
    }
}
