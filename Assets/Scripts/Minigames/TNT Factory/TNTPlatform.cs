using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTPlatform : MonoBehaviour
{
    public enum TNT {T, N}

    public TNT type;

    public bool isActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(type.ToString()))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(type.ToString()))
        {
            isActive = false;
        }
    }
}
