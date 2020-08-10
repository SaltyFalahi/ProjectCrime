using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTimer : MonoBehaviour
{
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
            Debug.Log("Red won");
        }
    }
}
