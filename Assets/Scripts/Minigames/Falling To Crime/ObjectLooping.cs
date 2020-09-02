using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLooping : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;

    public float speed = -1f;

    private void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y >= endPos.position.y)
        {
            transform.position = startPos.position;
        }
    }

    void SetTransformY(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);
    }
}
