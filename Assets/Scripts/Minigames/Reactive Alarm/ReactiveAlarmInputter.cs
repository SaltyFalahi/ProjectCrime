using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveAlarmInputter : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    public GameObject buttonObj;

    public string x;
    public string y;
    public string a;
    public string b;

    public string input;

    public int score;

    void Start()
    {
        GetPlayer();
    }

    void Update()
    {
        if (buttonObj.activeInHierarchy)
        {
            if (Input.GetButtonDown(x))
            {
                input = "X";
            }
            if (Input.GetButtonDown(a))
            {
                input = "A";
            }
            if (Input.GetButtonDown(b))
            {
                input = "B";
            }
            if (Input.GetButtonDown(y))
            {
                input = "Y";
            }
        }
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                x = "P1Fire1";
                a = "P1Fire2";
                b = "P1Fire3";
                y = "P1Fire4";
                break;

            case player.P2:
                x = "P2Fire1";
                a = "P2Fire2";
                b = "P2Fire3";
                y = "P2Fire4";
                break;

            case player.P3:
                x = "P3Fire1";
                a = "P3Fire2";
                b = "P3Fire3";
                y = "P3Fire4";
                break;

            case player.P4:
                x = "P4Fire1";
                a = "P4Fire2";
                b = "P4Fire3";
                y = "P4Fire4";
                break;
        }
    }
}
