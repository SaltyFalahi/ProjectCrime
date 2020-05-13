using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSpace : MonoBehaviour
{
    public int count;

    PlayerInfo player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerInfo>();
            //Roll 1d4 and move backwards
        }
    }
}
