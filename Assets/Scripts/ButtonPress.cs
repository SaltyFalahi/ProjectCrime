using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    public string button = null;

    public bool myTurn;

    string fire1;
    string fire2;
    string fire3;
    string fire4;

    void Start()
    {
        GetPlayer();
    }

    void Update()
    {
        if (myTurn)
        {
            if (Input.GetButtonDown(fire1))
            {
                button = "Square";
                myTurn = false;
            }
            else if (Input.GetButtonDown(fire2))
            {
                button = "Cross";
                myTurn = false;
            }
            else if (Input.GetButtonDown(fire3))
            {
                button = "Circle";
                myTurn = false;
            }
            else if (Input.GetButtonDown(fire4))
            {
                button = "Triangle";
                myTurn = false;
            }
        }
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                fire1 = "P1Fire1";
                fire2 = "P1Fire2";
                fire3 = "P1Fire3";
                fire4 = "P1Fire4";
                break;

            case player.P2:
                fire1 = "P2Fire1";
                fire2 = "P2Fire2";
                fire3 = "P2Fire3";
                fire4 = "P2Fire4";
                break;

            case player.P3:
                fire1 = "P3Fire1";
                fire2 = "P3Fire2";
                fire3 = "P3Fire3";
                fire4 = "P3Fire4";
                break;

            case player.P4:
                fire1 = "P4Fire1";
                fire2 = "P4Fire2";
                fire3 = "P4Fire3";
                fire4 = "P4Fire4";
                break;
        }
    }
}
