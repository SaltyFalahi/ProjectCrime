using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReciever : MonoBehaviour
{
    public SocketIOComponent soc;

    public string button;

    void Start()
    {
        soc.On("input", (soc) =>
        {
            button = (string)soc.data.GetField("Button Pressed");
        });
    }
}
