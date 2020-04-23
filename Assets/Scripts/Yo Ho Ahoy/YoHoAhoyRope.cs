using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoHoAhoyRope : MonoBehaviour
{
    public List<ButtonPress> buttons;
    public List<int> chosen;

    public float timer;

    float countdown;

    void Start()
    {
        countdown = timer;
    }

    void Update()
    {
        if (countdown <= 0)
        {

        }
        else
        {
            for (int i = 1; i < buttons.Count; i++)
            {
                
            }
        }
    }
}
