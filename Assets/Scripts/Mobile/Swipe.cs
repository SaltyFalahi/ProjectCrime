using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public SocketIOComponent soc;

    public float deadzone;

    Vector2 swipeDelta;
    Vector2 startTouch;

    string swipe;

    bool tap;
    bool swipeLeft;
    bool swipeRight;
    bool swipeUp;
    bool swipeDown;
    bool isDragging;

    void Start()
    {
        
    }

    void Update()
    {
        tap = false;
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
        swipeDown = false;

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = true;
            ResetSwipe();
        }

        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = true;
                ResetSwipe();
            }
        }

        swipeDelta = Vector2.zero;

        if (isDragging)
        {
            if (Input.touchCount > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude > deadzone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeLeft = true;
                    //Send Message Left to Server
                    swipe = "Left";
                }
                else
                {
                    swipeRight = true;
                    //Send Message Right to Server
                    swipe = "Right";
                }
            }
            else
            {
                if (y < 0)
                {
                    swipeDown = true;
                    //Send Message Down to Server
                    swipe = "Down";
                }
                else
                {
                    swipeUp = true;
                    //Send Message Up to Server
                    swipe = "Up";
                }
            }

            JSONObject jdata = new JSONObject();
            jdata.AddField("Swipe Registered", swipe);

            soc.Emit("Input Swipe", jdata);

            ResetSwipe();
        }
    }

    void ResetSwipe()
    {
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
        isDragging = false;
    }
}
