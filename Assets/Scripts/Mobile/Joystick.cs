using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform circle;
    public Transform Outercircle;

    Vector2 pointA;
    Vector2 pointB;

    bool touchStart;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        }

        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        }
        else
        {
            touchStart = false;
        }
    }

    void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1);
            MoveCharacter(direction);

            circle.position = new Vector2(Outercircle.position.x + direction.x, Outercircle.position.y + direction.y);
        }
    }

    void MoveCharacter(Vector2 dir)
    {
        //Send Direction to Server

    }
}
