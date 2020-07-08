using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public SocketIOComponent soc;

    string button;

    public void ButtonPressed(int index)
    {
        switch (index)
        {
            case 0:
                //Send Message Top to Server
                button = "Top";
                break;

            case 1:
                //Send Message Right to Server
                button = "Right";
                break;

            case 2:
                //Send Message Left to Server
                button = "Left";
                break;

            case 3:
                //Send Message Bottom to Server
                button = "Bottom";
                break;
        }

        JSONObject jdata = new JSONObject();
        jdata.AddField("Button Pressed", button);

        soc.Emit("Input Button", jdata);
    }
}
