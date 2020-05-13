using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpace : MonoBehaviour
{
    public int count;

    PlayerInfo player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerInfo>();
            player.bucks -= count;
        }
    }
}
