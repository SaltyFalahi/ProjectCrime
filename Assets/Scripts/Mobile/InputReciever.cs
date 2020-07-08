using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReciever : MonoBehaviour
{
    public SocketIOComponent soc;

    public Vector3 tilt;

    public Vector2 direction;

    public string button;
    public string swipe;

    void Start()
    {
        soc.On("Input Button", (soc) =>
        {
            button = (string)soc.data.GetField("Button Pressed");
        });

        soc.On("Input Tilt", (soc) =>
        {
            tilt.x = soc.data.GetField("X").f;
            tilt.y = soc.data.GetField("Y").f;
            tilt.z = soc.data.GetField("Z").f;
        });

        soc.On("Input Direction", (soc) =>
        {
            direction.x = soc.data.GetField("X").f;
            direction.y = soc.data.GetField("Y").f;
        });

        soc.On("Input Swipe", (soc) =>
        {
            swipe = (string)soc.data.GetField("Swipe Registered");
        });
    }
}
