﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject balloon;

    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    public float score;
    public float pumpLimit = 1;

    public bool isPopped = false;

    float pumpScale = 0.005f;
    float pumpMid = 0.5f;
    float pumpQuart = 0.25f;

    string pump;

    Vector3 scaleObj;

    void Start()
    {
        GetPlayer();
        scaleObj = new Vector3(pumpScale, pumpScale, pumpScale);
    }

    void Update()
    {
        if (Input.GetButtonDown(pump))
        {
            balloon.transform.localScale += scaleObj;
            score = balloon.transform.localScale.x;

            if (balloon.transform.localScale.x >= pumpMid)
            {
                pumpScale = 0.0025f;
            }

            if (balloon.transform.localScale.x >= pumpQuart && balloon.transform.position.y <= 4)
            {
                balloon.transform.position = new Vector3(balloon.transform.position.x, 
                    balloon.transform.position.y + 1 * Time.deltaTime, balloon.transform.position.z);
            }
        }

        if (balloon.transform.localScale.x >= pumpLimit)
        {
            isPopped = true;
            Destroy(balloon);
            pumpScale = 0;
            score = 0;
        }
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                pump = "P1Fire1";
                break;

            case player.P2:
                pump = "P2Fire1";
                break;

            case player.P3:
                pump = "P3Fire1";
                break;

            case player.P4:
                pump = "P4Fire1";
                break;
        }
    }
}
