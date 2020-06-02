using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
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
    }
}
