using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    public SocketIOComponent soc;

    public bool isFlat;

    void Start()
    {

    }

    void Update()
    {
        Vector3 tilt = Input.acceleration;

        if(isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }

        //Send tilt to Server
        JSONObject jdata = new JSONObject();
        jdata.AddField("X", tilt.x);
        jdata.AddField("Y", tilt.y);
        jdata.AddField("Z", tilt.z);

        soc.Emit("Input Tilt", jdata);
    }
}
