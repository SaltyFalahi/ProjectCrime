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
            transform.position = new Vector3(parent.GetChild(0).transform.position.x + 1.6f, parent.GetChild(0).transform.position.y + 1,
                parent.GetChild(0).transform.position.z);
        }
    }
}
