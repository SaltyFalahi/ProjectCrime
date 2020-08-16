using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    public Transform parent;

    public bool isBeingCarried;

    void Start()
    {
        isBeingCarried = false;
    }

    void Update()
    {
        if (parent)
        {
            transform.position = parent.GetChild(0).transform.position;
        }
    }
}
