using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpace : MonoBehaviour
{
    public int count;

    PlayerInfo player;

    private void OnTriggerEnter(Collider other)
    {
        //If player walks into the space
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerInfo>();
            //Lose bucks
            player.bucks -= count;
        }
    }
}
